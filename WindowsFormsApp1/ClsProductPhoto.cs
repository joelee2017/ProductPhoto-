using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WindowsFormsApp1.Properties;
using System.IO;
using WindowsFormsControlLibrary1;
using System.Drawing;

namespace WindowsFormsApp1
{
   public class ClsProductPhoto
    {
        
        public static List<string> ProductLoad()//All Years
        {
            SqlConnection sqlconn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            List<string> yearlist = new List<string>();

            using (sqlconn = new SqlConnection(Settings.Default.ADW))
            using (comm = new SqlCommand("select distinct YEAR(ModifiedDate) AS Year from Production.ProductPhoto", sqlconn))
            {
                sqlconn.Open();
                SqlDataReader dataReader = comm.ExecuteReader();
                yearlist.Add("All Years");
                while (dataReader.Read())
                {
                    yearlist.Add(dataReader["Year"].ToString());
                }
            }
            return yearlist;
                           
        }

        public static List<UserControl1> commtool(string commtxt)//連線公用
        {
            List<UserControl1> Uscommtool = new List<UserControl1>();
            string sda = Settings.Default.ADW;
            using (SqlConnection conn = new SqlConnection(sda))
            using (SqlCommand comm = new SqlCommand(commtxt, conn))
            {
                conn.Open();
                SqlDataReader dataReader = comm.ExecuteReader();

                while (dataReader.Read())
                {
                    byte[] by = (byte[])dataReader["LargePhoto"];//datareader讀到的資料放到byte之中
                    string name = (string)dataReader["LargePhotoFileName"];
                    UserControl1 us = new UserControl1();
                    using (MemoryStream ms = new MemoryStream(by))
                    {
                        us.Btnpicture = Image.FromStream(ms);
                        us.BtnName = name;
                    }
                    Uscommtool.Add(us);
                }
            }
            return Uscommtool;

        }

        public static List<UserControl1> panelshow(string comtxt)
        {
            string commtxt = "select LargePhoto,LargePhotoFileName from Production.ProductPhoto where YEAR(ModifiedDate) ="+ comtxt;
            return commtool(commtxt);
        }

        public static List<UserControl1> panelshow()
        {
            string commtxt = "select LargePhoto,LargePhotoFileName from Production.ProductPhoto";
            return commtool(commtxt);
        }


        public Color Color1 { get; set; }//自動實作

        private Color m_Color2;
        public Color Color2
        {
            get
            {
                return m_Color2;
            }
            set
            {
                this.m_Color2 = value;                
            }
        }

    }
}
