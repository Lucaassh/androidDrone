using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vacation_Atualiza
{
    public partial class Form2 : Form
    {
        private string conn;
        private MySqlConnection connect;

        public Form2()
        {
            InitializeComponent();
        }

        private void preencher()
        {
            try
            {
                conn = "Server=3.128.7.77;Database=database1;Uid=admin;Pwd=Alohomora01;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM encomendas", connect);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable data = new DataTable();
            adapter.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            preencher();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn = "Server=3.128.7.77;Database=database1;Uid=admin;Pwd=Alohomora01;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException d)
            {
                throw;
            }

            MySqlCommand cmd = new MySqlCommand("DELETE FROM encomendas WHERE id=@id", connect);
            cmd.Parameters.AddWithValue("@id", textBox1.Text);
            MySqlDataReader delete = cmd.ExecuteReader();
                                    
            MessageBox.Show("Encomenda Deletada");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            String status = "Registrado";
            try
            {
                conn = "Server=3.128.7.77;Database=database1;Uid=admin;Pwd=Alohomora01;";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException d)
            {
                throw;
            }

            MySqlCommand cmd = new MySqlCommand("INSERT INTO encomendas (codigoRastreio, empresa, stats) VALUES (@codigoRastreio,@empresa,@stats)", connect);
            cmd.Parameters.AddWithValue("@codigoRastreio", textBox2.Text);
            cmd.Parameters.AddWithValue("@empresa", comboBox1.Text);
            cmd.Parameters.AddWithValue("@stats", status);
            MySqlDataReader inset = cmd.ExecuteReader();

            MessageBox.Show("Encomenda Registrada");
        }
    }

}
