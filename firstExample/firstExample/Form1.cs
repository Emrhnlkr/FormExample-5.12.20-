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
namespace firstExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Veritabanı bağlantısını gerçekleştirildi.
        SqlConnection connect =new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Bilgiler;Integrated Security=True");
        
        //Tüm verileri göstern fonk yazıldı.
        private void dataShow()
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("Select * From Kişiler", connect); //sorgu ile tablodaki veriler alındı.
            SqlDataReader read = command.ExecuteReader();
            while (read.Read()) //tablodaki verileri okundu
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["Ad"].ToString();
                add.SubItems.Add(read["Soyad"].ToString());
                add.SubItems.Add(read["Yaş"].ToString());
                add.SubItems.Add(read["İlçe"].ToString());
                add.SubItems.Add(read["Meslek"].ToString());

                listView1.Items.Add(add);
            }
            connect.Close();
        }
          
        private void button1_Click(object sender, EventArgs e)
        {
            dataShow();
            textBox1.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("Select * From Kişiler where Ad like '%"+textBox1.Text+"%'", connect);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["Ad"].ToString();
                add.SubItems.Add(read["Soyad"].ToString());
                add.SubItems.Add(read["Yaş"].ToString());
                add.SubItems.Add(read["İlçe"].ToString());
                add.SubItems.Add(read["Meslek"].ToString());

                listView1.Items.Add(add);

            }
            connect.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
