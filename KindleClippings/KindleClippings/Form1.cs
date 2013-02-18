using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Entity;
using Core;

namespace KindleClippings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public readonly Manager Joe = new Manager();

        List<Clipping> list;

        private void Form1_Load(object sender, EventArgs e)
        {
            populateDataGridView();
        }

        // Populate dataGridView1
        private void populateDataGridView()
        {
            if (Joe.existBase())
            {
                Int32 index = 0,
                      j = 0;

                list = Joe.getDB();

                var sortedClippings =
                    from element in list
                    group element by element.title into newGroup
                    orderby newGroup.Key
                    select newGroup;

                dataGridView1.Rows[index].Cells[0].Value = sortedClippings.ElementAt(index).Key;

                for (index = 1; index < sortedClippings.Count(); index++)
                {

                    DataGridViewRow row = (DataGridViewRow)this.dataGridView1.Rows[0].Clone();
                    row.Cells[0].Value = sortedClippings.ElementAt(index).Key;
                    this.dataGridView1.Rows.Add(row);

                }

                foreach (var clipping in sortedClippings.ElementAt(index-2))
                {
                    this.dataGridView2.Rows.Add();
                    dataGridView2.Rows[j].Cells[0].Value = clipping.text;

                    j++;
                }

            }
            else
            {
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Rows[e.RowIndex].Cells["title"].Value != null)
            {
                this.dataGridView2.Rows.Clear();
                this.dataGridView2.Refresh();

                var sortedClippings =
                    from element in list
                    group element by element.title into newGroup
                    orderby newGroup.Key
                    where newGroup.Key == dataGridView1.Rows[e.RowIndex].Cells["title"].Value
                    select newGroup;

                Int32 i = 0;

                foreach (var elem in sortedClippings)
                {

                    foreach (var clipping in elem)
                    {
                        this.dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = clipping.text;

                        i++;
                    }
                }
            }
        }

        // Open file
        private void ItemFile_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FileName = "My Clippings.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Joe.readFromFile(openFileDialog1.FileName);
                populateDataGridView();
            }
            else
            {
            }
        }

        // Exit
        private void ItemFile_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void copySelectedRowsToClipboard(DataGridView dgv)
        {
            dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            Clipboard.Clear();
            if (dgv.GetClipboardContent() != null)
            {
                Clipboard.SetDataObject(dgv.GetClipboardContent());
                Clipboard.GetData(DataFormats.Text);
                IDataObject dt = Clipboard.GetDataObject();
                if (dt.GetDataPresent(typeof(string)))
                {
                    string tb = (string)(dt.GetData(typeof(string)));
                    Encoding encoding = Encoding.GetEncoding(1251);
                    byte[] dataStr = encoding.GetBytes(tb);
                    Clipboard.SetDataObject(encoding.GetString(dataStr));
                }
            }
            dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
        }

        private void ItemCopyToClipboard_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2
                .GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    // Add the selection to the clipboard.
                    Clipboard.SetDataObject(
                        this.dataGridView2.GetClipboardContent());
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                }
            }
        }

        public void openElementForm()
        {
            ElementForm Form = new ElementForm();

            Form.title = this.dataGridView1.SelectedCells[0].Value.ToString();
            Form.text = this.dataGridView2.SelectedCells[0].Value.ToString();

            Form.ShowDialog();
        }

        private void ItemOpen_Click(object sender, EventArgs e)
        {
            openElementForm();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            openElementForm();
        }

        private void ItemFile_Save_Click(object sender, EventArgs e)
        {
            Joe.saveBaseToFile(createTextBasePath().ToString());

        }

        private string createTextBasePath()
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FileName = "*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog1.FileName;
            }
            else
            {
                return "";
            }
        }

        private void ItemSaveToFile_Click(object sender, EventArgs e)
        {
            Joe.saveBookClippingsToFile(createTextBasePath().ToString(), this.dataGridView1.SelectedCells[0].Value.ToString());

        }
    }
}
