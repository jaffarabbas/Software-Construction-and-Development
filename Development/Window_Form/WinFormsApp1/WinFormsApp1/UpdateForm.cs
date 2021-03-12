using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WinFormsApp1
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            txtUpdateFile.Text = Form1.SetValueFortxtDataPiker;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Want To Update ? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UpdateFile(Form1.SetValueForFilePath);
                this.Close();
            }
        }

        private void UpdateFile(string filepath)
        {
            string file = @"J:\Semester-4(Bsse)\Software-Construction-and-Development\Development\Window_Form\WinFormsApp1\files\" + filepath;
            StreamWriter writer = new StreamWriter(file);
            writer.Write(txtUpdateFile.Text);
            writer.Close();
        }


    }
}
