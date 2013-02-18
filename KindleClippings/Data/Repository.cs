using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Entity;

namespace Data
{
    public class Repository: IRepository
    {
        public string fileName = "ClipppingDB.xml";
        private XDocument doc;

        public Repository()
        {
        }

        // Create DB
        public void Create(string _fileName)
        {
            fileName = _fileName;
            doc = new XDocument(new XElement("clippings"));
            doc.Save(fileName);
        }

        // Save DB
        private void Save()
        {
            try
            {
                doc.Save(fileName);
            }
            catch
            {
            }
        }

        // Add element to DB
        public void Add(Clipping element)
        {
            doc = XDocument.Load(fileName);
            doc.Root.Add(new XElement("clipping",
                new XAttribute("id", element.Id),
                new XElement("title", element.title),
                new XElement("text", element.text)));
            Save();
        }

        // Update element in DB
        public void Update(Int32 id, Clipping element)
        {
            doc = XDocument.Load(fileName);
            XElement currentBook = doc.Root.Elements()
                .First(t => t.Attribute("id").Value == id.ToString());

            if (element.title != null)
                currentBook.Element("title").Value = element.title;
            else
                currentBook.Element("title").Value = "Lorep ipsum";

            if (element.text != null)
                currentBook.Element("text").Value = element.text;
            else
                currentBook.Element("text").Value = "Lorep ipsum";
            
            Save();
        }

        // Delete element from DB
        public void Delete(Int32 id)
        {
            doc.Root.Elements()
               .First(t => t.Attribute("id").Value == id.ToString())
               .Remove();
            Save();
        }

        // Return DB as list
        public List<Clipping> GetAll()
        {

            doc = XDocument.Load(fileName);
            List<Clipping> list = new List<Clipping>();
            foreach (XElement el in doc.Root.Elements())
            {
                Clipping elem = new Clipping();
                elem.Id = Convert.ToInt32(el.Attribute("id").Value);

                elem.title = el.Element("title").Value;
                elem.text = el.Element("text").Value;

                list.Add(elem);
            }

            return list;
        }

        public List<Clipping> GetBookClippings(string title)
        {
            doc = XDocument.Load(fileName);
            List<Clipping> list = new List<Clipping>();
            foreach (XElement el in doc.Root.Elements().Where(x => x.Element("title").Value == title))
            {
                Clipping elem = new Clipping();
                elem.Id = Convert.ToInt32(el.Attribute("id").Value);

                elem.title = el.Element("title").Value;
                elem.text = el.Element("text").Value;

                list.Add(elem);
            }

            return list;
        }
    }
}
