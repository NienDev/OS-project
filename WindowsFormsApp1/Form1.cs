using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int originalPanelSize_width, originalPanelSize_height;
        public Form1()
        {
            InitializeComponent();

            originalPanelSize_width = panel1.Width;
            originalPanelSize_height = panel1.Height;

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            for (int i =0; i < allDrives.Length; i++)
            {
                if (allDrives[i].DriveType.ToString() == "Removable")
                {
                    // create objects
                    drive_labels[i] = new Label();

                    // set properties
                    drive_labels[i].Location = new Point(100, 100 *i);
                    drive_labels[i].Name = "drive_label_" + i.ToString();
                    drive_labels[i].Text = "Drive label " + i.ToString();
                    
                    // add to controls
                    Controls.Add(drive_labels[i]);
                }
            }

           
        }

        private void form1_Load(object sender, EventArgs e)
        {
            if (imageList1.Images.Count > 0){
                pictureBox1.Image = imageList1.Images[0];
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Size = new Size(220, 120);
            label1.Font= new Font("Microsoft Sans Serif", 18.25F, FontStyle.Bold);
            label2.Font = new Font("Microsoft Sans Serif", 14.25F);
            pictureBox1.Size = new Size(100, 90);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.Size = new Size(188, 100);
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            label2.Font = new Font("Microsoft Sans Serif", 10.25F);
            pictureBox1.Size = new Size(86, 77);
        }

    }
}
