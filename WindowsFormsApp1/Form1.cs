using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsControlLibrary1;
using WindowsFormsApp1.Properties;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
                        
            cls.Color1 = Color.OrangeRed;
            cls.Color1 = Color.Bisque;

        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }


        ClsProductPhoto cls = new ClsProductPhoto();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            Point pt1 = new Point(0, 0);
            Point pt2 = new Point(0, this.ClientRectangle.Height);
            LinearGradientBrush brush1 = new LinearGradientBrush(pt1, pt2,cls.Color1,cls.Color2);
            g.FillRectangle(brush1, this.ClientRectangle);

        }

        UserControl1 uc = new UserControl1();

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.comboBox1.DataSource = ClsProductPhoto.ProductLoad();
            //using (SqlConnection conn = new SqlConnection(Settings.Default.ADW))
            //{
            //    using (SqlCommand comm = new SqlCommand
            //                ("select distinct YEAR(ModifiedDate) AS Year from Production.ProductPhoto", conn))
            //    {
            //        this.comboBox1.Items.Clear();
            //        this.comboBox1.Items.Add("All Years");
            //        conn.Open();
            //        SqlDataReader dataReader = comm.ExecuteReader();                    
                   
            //        while(dataReader.Read())
            //        {
            //            this.comboBox1.Items.Add(dataReader["Year"]);
                      
            //        }
            //        this.comboBox1.SelectedIndex = 0;
            //    }
            //}            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<UserControl1> Newcon = new List<UserControl1>();
            if(comboBox1.Text == "All Years")
            {
                Newcon = ClsProductPhoto.panelshow();                
            }
            else
            {
                Newcon = ClsProductPhoto.panelshow(comboBox1.Text);
            }
            for (int i = 0; i <= Newcon.Count - 1; i++)
            {
                flowLayoutPanel1.Controls.Add(Newcon[i]);
            }
            //using (SqlConnection conn = new SqlConnection(Settings.Default.ADW))


            //    if (comboBox1.Text == "All Years")
            //    {
            //        flowLayoutPanel1.Controls.Clear();
            //        this.comboBox1.DataSource = ClsProductPhoto.ProductLoad();
            //        flowLayoutPanel1.Controls.Clear();
            //        using (SqlCommand comm = new SqlCommand("select LargePhoto,LargePhotoFileName from Production.ProductPhoto", conn))
            //        {
            //            conn.Open();
            //            SqlDataReader dataReader = comm.ExecuteReader();

            //            while (dataReader.Read())
            //            {
            //                byte[] by = (byte[])dataReader["LargePhoto"];//datareader讀到的資料放到byte之中
            //                using (MemoryStream ms = new MemoryStream(by))
            //                {
            //                    UserControl1 us = new UserControl1();
            //                    us.BtnName = dataReader["LargePhotoFileName"].ToString();
            //                    us.Btnpicture = Image.FromStream(ms);
            //                    flowLayoutPanel1.Controls.Add(us);
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        flowLayoutPanel1.Controls.Clear();
            //        using (SqlCommand comm = new SqlCommand ("select LargePhoto,LargePhotoFileName from Production.ProductPhoto where YEAR(ModifiedDate) =" + this.comboBox1.Text, conn))
            //        {
            //            conn.Open();
            //            SqlDataReader dataReader = comm.ExecuteReader();

            //            while (dataReader.Read())
            //            {
            //                byte[] by = (byte[])dataReader["LargePhoto"];//datareader讀到的資料放到byte之中
            //                using (MemoryStream ms = new MemoryStream(by))
            //                {
            //                    UserControl1 us = new UserControl1();
            //                    us.BtnName = dataReader["LargePhotoFileName"].ToString();
            //                    us.Btnpicture = Image.FromStream(ms);
            //                    flowLayoutPanel1.Controls.Add(us);
            //                }
            //            }
            //        }

            //    }

        }


    }
}
