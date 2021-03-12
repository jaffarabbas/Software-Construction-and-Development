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

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public static string SetValueFortxtDataPiker = "";
        public static string SetValueForFilePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateLstFileCollection();
        }

        private void PopulateLstFileCollection()
        {
            string filePath = @"J:\Semester-4(Bsse)\Software-Construction-and-Development\Development\Window_Form\WinFormsApp1\files";
            DirectoryInfo info = new DirectoryInfo(filePath);
            FileInfo[] fileCollection = info.GetFiles();
            for (int i = 0; i < fileCollection.Length; i++)
            {
                lstFileCollection.Items.Insert(i, fileCollection[i].Name);
            }
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDataPicker.Text))
            {
                FileLoad();
                lstFileCollection.Items.Clear();
                PopulateLstFileCollection();
            }
            else
            {
                AlertMessage("Please Enter Any Text", "Error!!");
            }
        }

        private void FileLoad()
        {
            string file =@"J:\Semester-4(Bsse)\Software-Construction-and-Development\Development\Window_Form\WinFormsApp1\files\FIle_Name_"+KeyMaker()+".txt";
            StreamWriter writer = new StreamWriter(file,true);
            writer.Write(txtDataPicker.Text);
            writer.Close();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            lstViewFileData.Items.Clear();
            if (lstFileCollection.SelectedIndex != -1)
            {
                lstViewFileData.Items.Add(ReadFile(lstFileCollection.SelectedItem.ToString()));
            }
            else
            {
                AlertMessage("Please Select Any Feild", "Error!!");
            }
        }

        private string ReadFile(string filepath)
        {
            string file = @"J:\Semester-4(Bsse)\Software-Construction-and-Development\Development\Window_Form\WinFormsApp1\files\"+ filepath;
            StreamReader read = new StreamReader(file);
            string fileData = read.ReadToEnd();
            read.Close();
            return fileData;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lstFileCollection.SelectedIndex != -1)
            {
                if(MessageBox.Show("Do You Want To Delete ? ","Confirmation",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteFile(lstFileCollection.SelectedItem.ToString());
                }
                lstFileCollection.Items.Clear();
                PopulateLstFileCollection();
            }
            else
            {
                AlertMessage("Please Select Any Feild", "Error!!");
            }
        }

        private void DeleteFile(string filepath)
        {
            string file = @"J:\Semester-4(Bsse)\Software-Construction-and-Development\Development\Window_Form\WinFormsApp1\files\" + filepath;
            File.Delete(file);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstFileCollection.SelectedIndex != -1)
            {
                SetValueFortxtDataPiker = ReadFile(lstFileCollection.SelectedItem.ToString());
                SetValueForFilePath = lstFileCollection.SelectedItem.ToString();
                UpdateForm update = new UpdateForm();
                update.Show();
                lstFileCollection.Items.Clear();
                PopulateLstFileCollection();
            }
            else
            {
                AlertMessage("Please Select Any Feild", "Error!!");
            }
        }

        private void AlertMessage(string text,string caption)
        {
            MessageBox.Show(text,caption);
        }

        private string KeyMaker()
        {
            return DateTime.Now.Ticks.ToString();
        }
    }
}
