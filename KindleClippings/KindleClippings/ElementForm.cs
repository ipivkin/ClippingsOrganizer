using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity
{
    public partial class ElementForm : Form
    {
        public string title { get; set; }
        public string text { get; set; }

        public ElementForm()
        {
            InitializeComponent();
        }

        private void ElementForm_Load(object sender, EventArgs e)
        {
            this.labelTitle.Text = this.title;
            this.richTextBox1.AppendText(this.text);
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectedText.Count() > 0)
            {
                try
                {
                    Clipboard.SetText(this.richTextBox1.Text);
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                }
            }
        }
    }
}
