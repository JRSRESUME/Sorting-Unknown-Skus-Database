using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sku.Focus();
        }
        OleDbConnection connect = new OleDbConnection();
        private void send_Click(object sender, EventArgs e)
        {
            
            connect.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\MOOTADOE-PC\Downloads\db1.mdb";
            string skuz = sku.Text;
            connect.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT into userdata(sku)" + "values(@skuz)", connect);






            DataTable dt = new DataTable();
            OleDbDataAdapter SDA = new OleDbDataAdapter("SELECT * FROM userdata where Sku like " + sku.Text, connect);
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            connect.Close();
            sku.Text = "";


            try
            {
                bool fart = dt.Rows[0].Equals(DBNull.Value);
            }
            catch
            {
                connect.Open();
                cmd.Parameters.Add("@skuz", OleDbType.Char, 20).Value = skuz;

                cmd.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                OleDbDataAdapter SDA2 = new OleDbDataAdapter("SELECT * FROM userdata where Sku like " + skuz, connect);
                SDA2.Fill(dt2);
                dataGridView1.DataSource = dt2;
                connect.Close();
                sku.Text = "";
            }
            
            


        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
            
    }
}

