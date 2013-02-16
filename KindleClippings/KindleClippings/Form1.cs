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
using Entity;
using Core;

namespace KindleClippings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            populateDataGridView();
        }

        public readonly Manager Joe = new Manager();

        List<Clipping> list;

        // Choose Clippping.txt
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Joe.readFromFile(openFileDialog1.FileName);
            }
            else
            {
            }
        }

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
    }
}
