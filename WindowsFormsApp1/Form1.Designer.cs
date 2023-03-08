using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 

        

        //public int getNumberOfUSB()
        //{
        //    int ans = 0;
        //    for (int i = 0; i < allDrives.Length; i++)
        //    {
        //        if (allDrives[i].DriveType.ToString() == "Removable")
        //        {
        //            ans++;
        //        }
        //    }
        //    return ans;
        //}



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "usb-drive.png");
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(562, 47);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(270, 10);
            this.progressBar1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(562, 63);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(270, 302);
            this.treeView1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.progressBar1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.form1_Load);
            this.ResumeLayout(false);

        }


        #endregion
        private Label new_label;
        private Label[] drive_labels = new Label[100];
        private ImageList imageList1;
        private Panel panel2;

        // Drive component include: 
        private Panel[] drive_layouts_panels = new Panel[100];
        private Label[] drive_name_labels = new Label[100];
        private Label[] drive_format_labels = new Label[100];
        private PictureBox[] drive_image_pictureboxes = new PictureBox[100];
        private ProgressBar progressBar1;
        private TreeView treeView1;
    }
}

