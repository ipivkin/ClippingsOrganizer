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
            Int32 i = 0,
                  j = 0;

            list = Joe.getDB();

            var sortedClippings =
                from element in list
                group element by element.title into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var elem in sortedClippings)
            {
                this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = elem.Key;

                if (i == 0)
                {
                    foreach (var clipping in elem)
                    {
                        this.dataGridView2.Rows.Add();
                        dataGridView2.Rows[j].Cells[0].Value = clipping.text;

                        j++;
                    }
                }

                i++;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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

        // Open file
        private void ItemFile_Open_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Joe.readFromFile(openFileDialog1.FileName);
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
    }
}
