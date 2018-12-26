using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLLS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        #region AddNewControlBoxItem

        /// <summary>
        /// Adds the "New" ControlBox item
        /// </summary>
        private void AddNewControlBoxItem()
        {
            // Create a new button and add it to the ControlBox



            ButtonItem bi = new ButtonItem();

           
            bi.CustomColorName = "ControlBoxColorTable";
            bi.Click += AddTabClick;
           
        }


        #endregion

       

        /// <summary>
        /// Handles "Add Tab" ControlBox selections
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AddTabClick(object sender, System.EventArgs e)
        {
            

            SuperTabItem tab = stcMain.CreateTab("s");

            tab.ImageIndex = 0;

            
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {

            //SuperTabItem tab = stcMain.CreateTab("Cấu hình");
            //tab.ImageIndex = 0;
            stcMain.Visible = true;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string duongdan = txtChonFile.Text.Trim() + "";
            if (!string.IsNullOrWhiteSpace(duongdan))
            {
                StreamReader sr = new StreamReader(duongdan);
                do
                {
                    string a = sr.ReadLine();
                    MessageBox.Show(a);
                } while (sr.Peek() != -1);
               
            }
            
        }


        private void btnChonFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.InitialDirectory = @"C:\";
                openFile.DefaultExt = "txt";
                openFile.Filter = "txt files (*.txt)|*.txt";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    txtChonFile.Text = openFile.FileName;
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r+"");
            }

        }
    }
}
