using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace ID_Fimal_V00
{
    public partial class Form1 : Form   
    {


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CB_Ekle01.Text = "Please select";
            TextBox1.Text = dbAdres;
            DbOku();
        }


        #region Excel Değişkenleri
        public void pintu(string s)
        {
            con = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; " + "data source='" + s + " '; " + "Extended Properties=Excel 8.0;");
        }
        public OleDbConnection con;
        public OleDbCommand com;
        public DataSet ds;
        public OleDbDataAdapter oledbda;
        public DataTable dt;
        public string str;
        public string dbAdres = Application.StartupPath +  "\\db.xls";
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.ShowDialog();
            openfiledialog1.Filter = "allfiles|*.xls";

        }

        public void DbOku()
        {
            pintu(dbAdres);
            try
            {
                con.Open();
                str = "select * from [sheet1$]";
                com = new OleDbCommand(str, con);
                ds = new DataSet();
                oledbda = new OleDbDataAdapter(com);
                oledbda.Fill(ds, "[sheet1$]");
                con.Close();
                DataGridView1.DataSource = ds;
                DataGridView1.DataMember = "[sheet1$]";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                con.Open();
                str = "select * from [sheet1$]";
                com = new OleDbCommand(str, con);
                oledbda = new OleDbDataAdapter(com);
                ds = new DataSet();
                oledbda.Fill(ds, "[sheet1$]");
                con.Close();

                dt = ds.Tables["[sheet1$]"];
                int i = 0;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    CB_Ekle01.Items.Add(dt.Rows[i].ItemArray[0]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
     
        }

        private void CB_Ekle01_SelectedIndexChanged(object sender, EventArgs e)
        {

            CB_Ekle02.Items.Clear();
            CB_Ekle02.Text = "";
            try
            {
                con.Open();
                str = "select * from [sheet1$]";
                com = new OleDbCommand(str, con);
                oledbda = new OleDbDataAdapter(com);
                ds = new DataSet();
                oledbda.Fill(ds, "[sheet1$]");
                con.Close();

                dt = ds.Tables["[sheet1$]"];
                int i = 0;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    int j = 2;
                    CB_Ekle02.Items.Add(dt.Rows[i][CB_Ekle01.SelectedIndex + 1]); //.ItemArray[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void B_Ekle_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += CB_Ekle01.Text + " - " + CB_Ekle02.Text + " - " + CB_Ekle03.Text + Environment.NewLine;
        }



















        /*     Excel.Application ExcelUygulama;
                Excel.Workbook ExcelSayfa;
                object Missing = System.Reflection.Missing.Value;
                Excel.Range ExcelRange;

                int rowCnt = 0;
                int columnCnt = 0;

                string s_DosyaAdi = "";
                string s_Veri = "";
        */

    }
}
