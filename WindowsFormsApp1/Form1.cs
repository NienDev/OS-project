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

        // all drivers
        static DriveInfo[] allDrives = DriveInfo.GetDrives();

        static int getNumberOfUSB()
        {
            int ans = 0;
            for (int i = 0; i < allDrives.Length; i++)
            {
                if (allDrives[i].DriveType.ToString() == "Removable")
                {
                    ans++;
                }
            }
            return ans;
        }

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

        public DriveComponent[] drives = new DriveComponent[getNumberOfUSB()];

        public void loadTreeView(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.FullName, directoryInfo.Name);
            curNode.ImageIndex = 2;
            curNode.SelectedImageIndex = 1;
            curNode.StateImageIndex = 2;
            curNode.Tag = directoryInfo.FullName;
            try
            {

                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    TreeNode fileNode = curNode.Nodes.Add(file.FullName, file.Name);
                    fileNode.ImageIndex = 0;
                    fileNode.SelectedImageIndex = 0;
                    fileNode.Tag = file.FullName;
                    UpdateProgress();
                }
                foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
                {
                    loadTreeView(subdir, curNode.Nodes);
                    UpdateProgress();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void UpdateProgress()
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
                int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                progressBar1.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                Application.DoEvents();
            }
        }

        public Form1()
        {
            InitializeComponent();

            // Mouse out of treeView
            this.treeView1.MouseLeave += (s, e) =>
            {
                treeView1.SelectedNode = null;
            };

            // Mouse move in treeview
            treeView1.NodeMouseHover += (s, e) =>
            {
                // Get the node at the current mouse pointer location.
                TreeNode theNode = treeView1.GetNodeAt(treeView1.PointToClient(MousePosition));
                if (theNode != null && theNode.Tag != null)
                {
                    if (theNode.Tag.ToString() != this.toolTip1.GetToolTip(this.treeView1))
                        this.toolTip1.SetToolTip(this.treeView1, theNode.Tag.ToString());
                }
                else     // Pointer is not over a node so clear the ToolTip.
                {
                    this.toolTip1.SetToolTip(this.treeView1, "");
                }
            };
            
            


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

      

                // name
                drives[i].name.AutoSize = true;
                drives[i].name.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
                drives[i].name.Location = new Point(125, 24);
                drives[i].name.Name = "drive_name_label_" + i.ToString();
                drives[i].name.Size = new Size(66, 24);
                drives[i].name.Text = usb_names[i];
                


                // format
                drives[i].format.AutoSize = true;
                drives[i].format.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
                drives[i].format.Location = new System.Drawing.Point(125, 53);
                drives[i].format.Name = "drive_format_label_" + i.ToString();
                drives[i].format.Size = new System.Drawing.Size(46, 17);
                drives[i].format.Text = usb_formats[i];
          

                // image
                drives[i].image.InitialImage = null;
                drives[i].image.Location = new Point(20, 10);
                drives[i].image.Name = "drive_image_pictureboxes_" + i.ToString();
                drives[i].image.Size = new Size(86, 77);
                drives[i].image.SizeMode = PictureBoxSizeMode.Zoom;
                drives[i].image.TabStop = false;
       

                this.Controls.Add(drives[i].layout);
            }

            // Add Hover Effect
            int index = 0;
            foreach(DriveComponent component in drives)
            {
                if (component != null)
                {
                    component.image.Click += (s, e) => {

                        progressBar1.Value = 0;

                        foreach (DriveComponent component1 in drives)
                        {
                            // hide all components
                            component1.layout.Hide();
                        }

                        treeView1.Show();
                        progressBar1.Show();

                        DirectoryInfo directoryInfo = new DirectoryInfo(component.name.Text);
                        if (directoryInfo.Exists)
                        {
                            try
                            {
                                progressBar1.Maximum = Directory.GetFiles(component.name.Text, "*.*", SearchOption.AllDirectories).Length + Directory.GetDirectories(component.name.Text, "**", SearchOption.AllDirectories).Length;
                            }
                            catch (Exception ex)
                            {

                            }
                            treeView1.ImageList = imageList2;

                            loadTreeView(directoryInfo, treeView1.Nodes);
                        }
                    };
                   
                    component.image.MouseEnter += (sender, e) =>
                    {
                        PictureBox img = (PictureBox)sender;
                        Panel panel = (Panel)img.Parent;
                        panel.Size = new Size(211, 117);

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
   
        }

        private void form1_Load(object sender, EventArgs e)
        {
            if (imageList1.Images.Count > 0)
            {
                for (int i = 0; i < getNumberOfUSB(); i++)
                {
                    drives[i].image.Image = imageList1.Images[0];
                }
            }

            treeView1.Hide();
            progressBar1.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void driveImage_MouseEnter(object sender, EventArgs e)
        {

            MessageBox.Show("hover");
            PictureBox pictureBox = (PictureBox)sender;
        
            pictureBox.Size = new Size(100, 90);

     

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void driveImage_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;

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
       
        }
        private void driveLayout_MouseLeave(object sender, EventArgs e)
        {
            MessageBox.Show("panel out");
      

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
