using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        List<string> lstM3u8 = new List<string>();
        DataTable _dtGetM3u8 = new DataTable();
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
        /// <summary>
        /// đọc từng dòng trong file dẫn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string duongdan = txtChonFile.Text.Trim() + "";
            if (!string.IsNullOrWhiteSpace(duongdan))
            {
                StreamReader sr = new StreamReader(duongdan);
                do
                {
                    string link = sr.ReadLine();
                    string getM3u8 = "youtube-dl -g " + link;
                    lstM3u8.Add(getM3u8);
                    
                } while (sr.Peek() != -1);
                
                //_dtGetM3u8.Columns.Add("M3U8", typeof(string));
                if (lstM3u8.Count >0)
                {
                    foreach (string s in lstM3u8)
                    {
                        _dtGetM3u8.Rows.Add(s);
                    }
                    dgvM3u8.AutoGenerateColumns = true;
                    dgvM3u8.DataSource = _dtGetM3u8;
                }
               

            }
            
        }

        /// <summary>
        /// Chọn file chỉ ở định dang .txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private  string Getm3u8 (string cmdCommand)
        {
            
            Process cmd = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.CreateNoWindow = false; // ẩn hiện cmd
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
           
            cmd.StartInfo = startInfo;
            cmd.Start();

            cmd.StandardInput.WriteLine(cmdCommand);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            string result = cmd.StandardOutput.ReadToEnd();
            
            MessageBox.Show(result);

            Process q = new Process();
            q = null;
            q = Process.Start(startInfo);
            q.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            q.StandardInput.WriteLine(cmdCommand);
            q.StandardInput.Close();
            string myString = q.StandardOutput.ReadToEnd();
            MessageBox.Show(myString);
            return result;

        }
        private void btnGet_Click(object sender, EventArgs e)
        {


            if (_dtGetM3u8.Rows.Count >0)
            {
                foreach (DataRow dr in _dtGetM3u8.Rows)
                {
                    string link = dr["M3U8"] + "";
                    Getm3u8(link);

                }
            }


        }
    }
}
