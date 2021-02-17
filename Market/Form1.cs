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

namespace Market
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        SqlConnection connect= new SqlConnection("Data Source=DESKTOP-3EAMENA;Initial Catalog=MarketProject;Integrated Security=True");

        private void Data()
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand comm = new SqlCommand("Select *From Market", connect);
            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem insert = new ListViewItem();
                insert.Text = reader["ID"].ToString();
                insert.SubItems.Add(reader["Name"].ToString());
                insert.SubItems.Add(reader["Price"].ToString());
                insert.SubItems.Add(reader["Unit"].ToString());
                insert.SubItems.Add(reader["Type"].ToString());
                insert.SubItems.Add(reader["Expirationdate"].ToString());

                listView1.Items.Add(insert);
            }
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand comm= new SqlCommand("insert into Market (ID,Name,Price,Unit,Type,Expirationdate) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + textBox6.Text.ToString() + "')", connect);

            comm.ExecuteNonQuery();
            connect.Close();
            Data();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text=string.Empty;
            textBox6.Clear();
        }

        int ID = 0;

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ID = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand comm = new SqlCommand(" update Market set ID='" + textBox1.Text.ToString() + "',Name='" + textBox2.Text.ToString() + "',Price='" + textBox3.Text.ToString() + "',Unit='" + textBox4.Text.ToString() + "',Type='" + comboBox1.Text.ToString() + "',Expirationdate='" + textBox6.Text.ToString() + "' where ID=" + ID + "", connect);
            comm.ExecuteNonQuery();
            connect.Close();
            Data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand comm = new SqlCommand("Delete From Market where ID =(" + ID + ")", connect);
            comm.ExecuteNonQuery();
            connect.Close();
            Data();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = string.Empty;
            textBox6.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand comm = new SqlCommand("Select *From Market where ID like '%" + textBox7.Text + "%' or Name like '%" + textBox7.Text + "%' or Price like '%" + textBox7.Text + "%'or Unit like '%" + textBox7.Text + "%' or Type like '%" + textBox7.Text + "%'", connect);

            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem insert = new ListViewItem();
                insert.Text = reader["ID"].ToString();
                insert.SubItems.Add(reader["Name"].ToString());
                insert.SubItems.Add(reader["Price"].ToString());
                insert.SubItems.Add(reader["Unit"].ToString());
                insert.SubItems.Add(reader["Type"].ToString());
               

                listView1.Items.Add(insert);
            }
            connect.Close();
        }
    }
}
