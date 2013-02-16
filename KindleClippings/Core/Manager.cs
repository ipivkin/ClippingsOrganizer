using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Data;
using Entity;

namespace Core
{
    public class Manager
    {
        public readonly Repository _db;

        string _dbName = "ClipppingDB.xml";

        public Manager()
        {
            _db = new Repository();
        }

        // DB
        ///////////////////////////////////
        // Create DB
        public void Create()
        {
            _db.Create(_dbName);
        }

        // Return DB to list
        List<Clipping> Read()
        {
            List<Clipping> list = new List<Clipping>();

            list = _db.GetAll();

            return list;
        }

        // Добавление в БД
        public void Add(Clipping elem)
        {
            _db.Add(elem);
        }

        // Update DB
        public void Update()
        {
            //_db.Update(id, temp);
        }

        // Delete from DB
        public void Delete()
        {
            //_db.Delete(id);
        }

        public void populateDB(List<Clipping> list)
        {
            if (!File.Exists(_dbName))
            {
                Create();
            }

            foreach (Clipping elem in list)
            {
                Add(elem);
            }
        }

        public List<Clipping> getDB()
        {
            return _db.GetAll();
        }
        ///////////////////////////////////

        ///////////////////////////////////
        // File
        public void readFromFile(String path)
        {
            string firstWord_RU = "- Ваша",
                   firstWord_EN = "- Your",
                   endClipping = "==========",
                   line_old = "",
                   nameBook = "",
                   textClipping = "";

            string[] lines;

            Int32 ind = 1,
                  pos,
                  Id = 0;

            bool nameFl = true;



            List<Clipping> list = new List<Clipping>();

            lines = File.ReadAllLines(path, Encoding.GetEncoding(1251));

            foreach (string line in lines)
            {
                if (!String.IsNullOrWhiteSpace(line))
                {
                    if (nameFl)
                    {
                        pos = line.IndexOf(firstWord_RU);

                        if (pos == -1)
                        {
                            pos = line.IndexOf(firstWord_EN);
                        }

                        switch (pos)
                        {
                            case 0:
                                nameBook = line_old;
                                nameFl = false;

                                break;
                            case -1:
                                line_old = line;
                                break;
                            default:
                                nameBook = line.Substring(0, pos);
                                nameFl = false;

                                break;
                        }
                    }
                    else
                    {
                        if (line == endClipping)
                        {
                            var clip = new Clipping();
                            clip.Id = Id;
                            clip.title = nameBook;
                            clip.text = textClipping;

                            list.Add(clip);

                            nameFl = true;
                            Id++;
                            textClipping = "";
                        }
                        else
                        {
                            textClipping += textClipping + line;
                        }
                    }
                }

                ind++;
            }

            // Order by title
            sortList(list);
            //

            populateDB(list);
            //writeToFile(list);
        }

        public void writeToFile(List<Clipping> list)
        {
            var sortedClippings =
                from element in list
                group element by element.title into newGroup
                orderby newGroup.Key
                select newGroup;

            string path = "";
            //Запись в файл
            foreach (var elem in sortedClippings)
            {
                path = @"C:/Вырезки/" + elem.Key + ".txt";
                try
                {
                    using (var streamWriter = new StreamWriter(path, false, Encoding.GetEncoding(1251)))
                    {

                        foreach (var clipping in elem)
                        {
                            streamWriter.WriteLine(clipping.text + "\n");
                            streamWriter.WriteLine("\n");
                        }

                        streamWriter.Close();
                    }
                }
                catch
                {
                }
            }

        }

        public void sortList(List<Clipping> list)
        {
            list.OrderBy(x => x.title).ToList();
        }
        ///////////////////////////////////
    }
}
