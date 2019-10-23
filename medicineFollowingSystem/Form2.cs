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

namespace medicineFollowingSystem
{
    public partial class Form2 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=... ;Initial Catalog= DB;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void HastaGetir()
        {

            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From Table_1", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            listView1.Items.Clear();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Tc"].ToString());
                ekle.SubItems.Add(oku["AdSoyad"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["ilac"].ToString());

                listView1.Items.Add(ekle);


            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaGetir();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert Into Table_1 (id, tc,AdSoyad,telefon,ilac) Values ( '" + textBox5.Text.ToString() + "' ,'" + textBox2.Text.ToString() + "', '" + textBox1.Text.ToString() + "', '" + textBox3.Text.ToString() + "', '" + textBox4.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            listView1.Items.Clear();
            HastaGetir();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }


        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete From Table_1 where id = (" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            HastaGetir();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[0].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update Table_1 set id='" + textBox5.Text.ToString() + "',tc= '" + textBox2.Text.ToString() + "',AdSoyad= '" + textBox1.Text.ToString() + "',telefon ='" + textBox3.Text.ToString() + "',ilac = '" + textBox4.Text.ToString() + "' where id =" + id + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            HastaGetir();
        }
    }
}
