using System;
using System.Windows.Forms;
using System.Xml;

namespace CaterpillarTools.forms
{
    public partial class MainScreen : Form
    {
        #region Fields
        private bool _expand;
        private PasswordDecoder _decoder;
        private SerialGetter _serial;
        
        private float _percentage;
        #endregion

        public MainScreen()
        {
            InitializeComponent();
        }

        #region InnerWindows

        private void closePassView_Click(object sender, EventArgs e)
        {
            passView.Visible = false;
        }

        private void passwordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            passView.Visible = true;
        }

        private void serialNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialView.Visible = true;
        }

        private void closeSerialView_Click(object sender, EventArgs e)
        {
            serialView.Visible = false;
        }

        #endregion

        #region VisualControls
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void editorButton_Click(object sender, EventArgs e)
        {
            Editor edit = new Editor();
            edit.Show();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SendToDecoder();
            GetSerial();
            toolStripProgressBar1.Value = 100;
        }
    
        private void MainScreen_FormClosing(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.CancelAsync();
            }
            catch (Exception ex)
            {
                Application.Exit();
            }
        }

        private void expandAllButton_Click(object sender, EventArgs e)
        {
            _expand = !_expand;

            if (_expand)
            {
                treeView1.ExpandAll();
            }
            else
            {
                treeView1.CollapseAll();
            }

            expandAllButton.Text = _expand ? "Collapse" : "Expand";
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            AddNode(_decoder.GetDocument().DocumentElement, treeView1.Nodes[0]);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _decoder?.ChangeCheckState(checkBox1.Checked);
            if (_decoder != null)
            {
                textBox1.Text = _decoder.GetTheftDeterentPass();
                textBox2.Text = _decoder.GetCustomerPassOne();
                textBox3.Text = _decoder.GetCustomerPassTwo();
            }
        }

        #endregion

        #region UserVoidCode
        private void SendToDecoder()
        {
            //Send file to decoder and decode the password

            _decoder = new PasswordDecoder(openFileDialog.FileName);


            textBox1.Text = _decoder.GetTheftDeterentPass();
            textBox2.Text = _decoder.GetCustomerPassOne();
            textBox3.Text = _decoder.GetCustomerPassTwo();

            treeView1.Nodes.Clear();

            treeView1.Nodes.Add(openFileDialog.FileName);

            backgroundWorker1.RunWorkerAsync();
            
        }

        public void GetSerial()
        {
            _serial = new SerialGetter(openFileDialog.FileName);
            textBox4.Text = _serial.GetECMSerial();
            textBox5.Text = _serial.GetENGSerial();
            textBox6.Text = _serial.GetTOOLVersion();
            textBox7.Text = _serial.GetTOOLSerial();
        }

        public void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            if (inXmlNode != null && inXmlNode.HasChildNodes)
            {
                var nodeList = inXmlNode.ChildNodes;
                int i;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    var xNode = inXmlNode.ChildNodes[i];
                    try
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                        });


                        var tNode = inTreeNode.Nodes[i];
                        AddNode(xNode, tNode);
                    }
                    catch (Exception ex)
                    {
                        //ignored
                    }
                }
            }
            else
            {
                try
                {
                    Invoke((MethodInvoker)delegate
                    {
                        if (inXmlNode != null) inTreeNode.Text = (inXmlNode.OuterXml).Trim();
                    });
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }
        }
        #endregion
    }
}
