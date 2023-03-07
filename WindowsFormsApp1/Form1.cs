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

        public class DriveComponent
        {
            public Panel layout = new Panel();
            public Label name = new Label();
            public Label format = new Label();
            public PictureBox image = new PictureBox();

            public DriveComponent()
            {
                layout = new Panel();
                name = new Label();
                format = new Label();
                image = new PictureBox();

                layout.SuspendLayout();
            }
        }

        public DriveComponent[] drives = new DriveComponent[100];

        public Form1()
        {
            InitializeComponent();

            List<string> usb_names = new List<string>();
            List<string> usb_formats = new List<string>();
            for (int i = 0; i < allDrives.Length; i++)
            {
                if (allDrives[i].DriveType.ToString() == "Removable")
                {
                    usb_names.Add(allDrives[i].Name);
                    usb_formats.Add(allDrives[i].DriveFormat);
                }
            }
            //foreach (string name in usb_names)
            //{
            //    MessageBox.Show(name);
            //}


                // create drive component
            for (int i = 0; i < allDrives.Length; i++)
            {
                if (allDrives[i].DriveType.ToString() == "Removable")
                {
                    drive_layouts_panels[i] = new Panel();
                    drive_name_labels[i] = new Label();
                    drive_format_labels[i] = new Label();
                    drive_image_pictureboxes[i] = new PictureBox();
                    drive_layouts_panels[i].SuspendLayout();

                }
            }

            for (int i = 0; i < getNumberOfUSB(); i++)
            {
                drives[i] = new DriveComponent();
            }


            


            // set properties
            //for (int i = 0; i < allDrives.Length; i++)
            //{
            //    if (allDrives[i].DriveType.ToString() == "Removable")
            //    {
                  
            //        // layout
            //        drive_layouts_panels[i].BackColor = SystemColors.Control;
            //        drive_layouts_panels[i].BorderStyle = BorderStyle.FixedSingle;
            //        drive_layouts_panels[i].Controls.Add(drive_name_labels[i]);
            //        drive_layouts_panels[i].Controls.Add(drive_format_labels[i]);
            //        drive_layouts_panels[i].Controls.Add(drive_image_pictureboxes[i]);
            //        drive_layouts_panels[i].Cursor = Cursors.Hand;
            //        drive_layouts_panels[i].ForeColor = SystemColors.ActiveCaptionText;
            //        drive_layouts_panels[i].Location = new Point(10, 10 * i * 10);
            //        drive_layouts_panels[i].Name = "drive_layouts_panels_" + i.ToString();
            //        drive_layouts_panels[i].Size = new Size(191, 97);
            //        //drive_layouts_panels[i].MouseEnter += (sender, e) => driveLayout_MouseEnter(allDrives[i].Name);
            //        //drive_layouts_panels[i].MouseEnter += new EventHandler(this.driveLayout_MouseEnter);
            //        //drive_layouts_panels[i].MouseLeave += new EventHandler(this.driveLayout_MouseLeave);


            //        // name
            //        drive_name_labels[i].AutoSize = true;
            //        drive_name_labels[i].Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            //        drive_name_labels[i].Location = new Point(112, 24);
            //        drive_name_labels[i].Name = "drive_name_label_" + i.ToString();
            //        drive_name_labels[i].Size = new Size(66, 24);
            //        drive_name_labels[i].Text = allDrives[i].Name;
            //        //drive_name_labels[i].MouseEnter += new EventHandler(this.driveName_MouseEnter);
            //        //drive_name_labels[i].MouseLeave += new EventHandler(this.driveName_MouseLeave);

            //        // format
            //        drive_format_labels[i].AutoSize = true;
            //        drive_format_labels[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            //        drive_format_labels[i].Location = new System.Drawing.Point(113, 53);
            //        drive_format_labels[i].Name = "drive_format_label_" + i.ToString();
            //        drive_format_labels[i].Size = new System.Drawing.Size(46, 17);
            //        drive_format_labels[i].Text = this.allDrives[i].DriveFormat;
            //        //drive_name_labels[i].MouseEnter += new EventHandler(this.driveFormat_MouseEnter);
            //        //drive_name_labels[i].MouseLeave += new EventHandler(this.driveFormat_MouseLeave);

            //        // image
            //        drive_image_pictureboxes[i].InitialImage = null;
            //        drive_image_pictureboxes[i].Location = new Point(20, 10);
            //        drive_image_pictureboxes[i].Name = "drive_image_pictureboxes_" + i.ToString();
            //        drive_image_pictureboxes[i].Size = new Size(86, 77);
            //        drive_image_pictureboxes[i].SizeMode = PictureBoxSizeMode.Zoom;
            //        drive_image_pictureboxes[i].TabStop = false;
            //        //dive_image_pictureboxes[i].MouseEnter += new System.EventHandler(this.driveImage_MouseEnter);
            //        //drive_image_pictureboxes[i].MouseLeave += new System.EventHandler(this.driveImage_MouseLeave);

            //        // Hover effect
            //        this.drive_image_pictureboxes[i].MouseEnter += (sender, e) =>
            //        {
                        
            //            MessageBox.Show(i.ToString());
            //            //PictureBox img = (PictureBox)sender;
            //            //Panel panel = (Panel)img.Parent;
            //            //drive_layouts_panels[i].Size = new Size(211, 117);

            //            //string s = "";
            //            //foreach (Control child in panel.Controls)
            //            //{
            //            //    switch (child.Name)
            //            //    {
            //            //        case "label1":
            //            //            child.Font = new Font("Microsoft Sans Serif", 18.25F, FontStyle.Bold);
            //            //            break;
            //            //        case "label2":
            //            //            child.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            //            //            break;
            //            //        default:
            //            //            child.Size = new Size(120, 110);
            //            //            break;
            //            //    }
            //            //}
            //        };

            //        drive_image_pictureboxes[i].MouseLeave += (sender, e) =>
            //        {

            //            //PictureBox img = (PictureBox)sender;
            //            //Panel panel = (Panel)img.Parent;
            //            //drive_layouts_panels[i].Size = new Size(191, 97);

            //            //foreach (Control child in panel.Controls)
            //            //{
            //            //    switch (child.Name)
            //            //    {
            //            //        case "label1":
            //            //            child.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            //            //            break;
            //            //        case "label2":
            //            //            child.Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Bold);
            //            //            break;
            //            //        default:
            //            //            child.Size = new Size(100, 90);
            //            //            break;
            //            //    }
            //            //}
            //        };


            //        this.Controls.Add(drive_layouts_panels[i]);
            //    }
            //}


            for (int i = 0; i < getNumberOfUSB(); i++)
            {
                // layout
                drives[i].layout .BackColor = SystemColors.Control;
                drives[i].layout.BorderStyle = BorderStyle.FixedSingle;
                drives[i].layout.Controls.Add(drives[i].name);
                drives[i].layout.Controls.Add(drives[i].format);
                drives[i].layout.Controls.Add(drives[i].image);
                drives[i].layout.Cursor = Cursors.Hand;
                drives[i].layout.ForeColor = SystemColors.ActiveCaptionText;
                drives[i].layout.Location = new Point(10, 10 * i * 10);
                drives[i].layout.Name = "drive_layouts_panels_" + i.ToString();
                drives[i].layout.Size = new Size(191, 97);
                //drive_layouts_panels[i].MouseEnter += (sender, e) => driveLayout_MouseEnter(allDrives[i].Name);
                //drive_layouts_panels[i].MouseEnter += new EventHandler(this.driveLayout_MouseEnter);
                //drive_layouts_panels[i].MouseLeave += new EventHandler(this.driveLayout_MouseLeave);


                // name
                drives[i].name.AutoSize = true;
                drives[i].name.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
                drives[i].name.Location = new Point(125, 24);
                drives[i].name.Name = "drive_name_label_" + i.ToString();
                drives[i].name.Size = new Size(66, 24);
                drives[i].name.Text = usb_names[i];
                //drive_name_labels[i].MouseEnter += new EventHandler(this.driveName_MouseEnter);
                //drive_name_labels[i].MouseLeave += new EventHandler(this.driveName_MouseLeave);

                // format
                drives[i].format.AutoSize = true;
                drives[i].format.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
                drives[i].format.Location = new System.Drawing.Point(125, 53);
                drives[i].format.Name = "drive_format_label_" + i.ToString();
                drives[i].format.Size = new System.Drawing.Size(46, 17);
                drives[i].format.Text = usb_formats[i];
                //drive_name_labels[i].MouseEnter += new EventHandler(this.driveFormat_MouseEnter);
                //drive_name_labels[i].MouseLeave += new EventHandler(this.driveFormat_MouseLeave);

                // image
                drives[i].image.InitialImage = null;
                drives[i].image.Location = new Point(20, 10);
                drives[i].image.Name = "drive_image_pictureboxes_" + i.ToString();
                drives[i].image.Size = new Size(86, 77);
                drives[i].image.SizeMode = PictureBoxSizeMode.Zoom;
                drives[i].image.TabStop = false;
                //dive_image_pictureboxes[i].MouseEnter += new System.EventHandler(this.driveImage_MouseEnter);
                //drive_image_pictureboxes[i].MouseLeave += new System.EventHandler(this.driveImage_MouseLeave);

                // Hover effect
                //this.drive_image_pictureboxes[i].MouseEnter += (sender, e) =>
                //{

                    
                    //PictureBox img = (PictureBox)sender;
                    //Panel panel = (Panel)img.Parent;
                    //drive_layouts_panels[i].Size = new Size(211, 117);

                    //string s = "";
                    //foreach (Control child in panel.Controls)
                    //{
                    //    switch (child.Name)
                    //    {
                    //        case "label1":
                    //            child.Font = new Font("Microsoft Sans Serif", 18.25F, FontStyle.Bold);
                    //            break;
                    //        case "label2":
                    //            child.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
                    //            break;
                    //        default:
                    //            child.Size = new Size(120, 110);
                    //            break;
                    //    }
                    //}
                //};

                //drive_image_pictureboxes[i].MouseLeave += (sender, e) =>
                //{

                    //PictureBox img = (PictureBox)sender;
                    //Panel panel = (Panel)img.Parent;
                    //drive_layouts_panels[i].Size = new Size(191, 97);

                    //foreach (Control child in panel.Controls)
                    //{
                    //    switch (child.Name)
                    //    {
                    //        case "label1":
                    //            child.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
                    //            break;
                    //        case "label2":
                    //            child.Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Bold);
                    //            break;
                    //        default:
                    //            child.Size = new Size(100, 90);
                    //            break;
                    //    }
                    //}
                //};


                this.Controls.Add(drives[i].layout);
            }

            int index = 0;
            foreach(DriveComponent component in drives)
            {
                if (component != null)
                {
                    component.image.MouseEnter += (sender, e) =>
                    {
                        PictureBox img = (PictureBox)sender;
                        Panel panel = (Panel)img.Parent;
                        panel.Size = new Size(211, 117);

                        string s = "";
                        foreach (Control child in panel.Controls)
                        {
                            if (child.Name.Contains("name"))
                            {
                                child.Font = new Font("Microsoft Sans Serif", 18.25F, FontStyle.Bold);
                            } else if (child.Name.Contains("format"))
                            {
                                child.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
                            } else
                            {
                                child.Size = new Size(110, 100);
                            }
                        }
                    };

                    component.image.MouseLeave += (sender, e) =>
                    {
                        PictureBox img = (PictureBox)sender;
                        Panel panel = (Panel)img.Parent;
                        panel.Size = new Size(191, 97);

                        foreach (Control child in panel.Controls)
                        {
                            if (child.Name.Contains("name"))
                            {
                                child.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
                            }
                            else if (child.Name.Contains("format"))
                            {
                                child.Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Bold);
                            }
                            else
                            {
                                child.Size = new Size(100, 90);
                            }
                        }
                    };
                }
            }
            

            //DriveInfo[] allDrives = DriveInfo.GetDrives();

            //for (int i =0; i < allDrives.Length; i++)
            //{
            //    if (allDrives[i].DriveType.ToString() == "Removable")
            //    {
            //        // create objects
            //        drive_labels[i] = new Label();

            //        // set properties
            //        drive_labels[i].Location = new Point(100, 100 *i);
            //        drive_labels[i].Name = "drive_label_" + i.ToString();
            //        drive_labels[i].Text = "Drive label " + i.ToString();

            //        // add to controls
            //        Controls.Add(drive_labels[i]);
            //    }
            //}


        }

        private void form1_Load(object sender, EventArgs e)
        {
            if (imageList1.Images.Count > 0)
            {
                pictureBox1.Image = imageList1.Images[0];

                //for (int i = 0; i < allDrives.Length; i++)
                //{
                //    if (allDrives[i].DriveType.ToString() == "Removable")
                //    {
                //        drive_image_pictureboxes[i].Image = imageList1.Images[0];
                //    }
                //}

                for (int i = 0; i < getNumberOfUSB(); i++)
                {
                    drives[i].image.Image = imageList1.Images[0];
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void driveImage_MouseEnter(object sender, EventArgs e)
        {

            //if (sender.GetType().ToString() == "Panel")
            //{

            //} else if (sender.GetType().ToString() == "Label")
            //{

            //} else
            //{

            //}
            MessageBox.Show("hover");
            PictureBox pictureBox = (PictureBox)sender;
            //Label[] labels = (Label[])sender;
            //PictureBox pictureBox = (PictureBox)sender;

            //panel.Size = new Size(220, 120);
            //labels[0].Font = new Font("Microsoft Sans Serif", 18.25F, FontStyle.Bold);
            //labels[1].Font = new Font("Microsoft Sans Serif", 14.25F);
            pictureBox.Size = new Size(100, 90);

            //int index = pictureBox.Name[pictureBox.Name.Length - 1];

            //driveName_MouseEnter((Label)drive_name_labels[index-1], EventArgs.Empty);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void driveImage_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            //panel.Size = new Size(188, 100);
            //label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            //label2.Font = new Font("Microsoft Sans Serif", 10.25F);
            pictureBox.Size = new Size(86, 77);

        }

        private void driveName_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Font = new Font("Microsoft Sans Serif", 18.25F, FontStyle.Bold);
        }
        private void driveName_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
        }
        private void driveFormat_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Bold);
        }

        private void driveFormat_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Font = new Font("Microsoft Sans Serif", 10.25F, FontStyle.Bold);
        }
        private void driveLayout_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("panel in");
            //Panel panel = (Panel)sender;
            //panel.Size = new Size(220, 120);
        }
        private void driveLayout_MouseLeave(object sender, EventArgs e)
        {
            MessageBox.Show("panel out");
            //Panel panel = (Panel)sender;
            //panel.Size = new Size(188, 100);

        }

    }
}
