using System;
using System.Windows.Forms;

namespace CaterpillarTools.forms
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }
    }
}