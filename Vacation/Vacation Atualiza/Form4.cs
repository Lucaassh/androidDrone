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
    public partial class Form4 : Form
    {

        private string conn;
        private MySqlConnection connect;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

                MySqlCommand cmd = new MySqlCommand("UPDATE usuarios SET nome=@nome, sexo=@sexo, cep=@cep WHERE id=2", connect);
                cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                cmd.Parameters.AddWithValue("@sexo", comboBox1.Text);
                cmd.Parameters.AddWithValue("@cep", textBox2.Text);
                MySqlDataReader inset = cmd.ExecuteReader();

                MessageBox.Show("Usuario Atualizado");
                
                this.Visible = false;
                Form3 newForm3 = new Form3();
                newForm3.ShowDialog();
                this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 newForm3 = new Form3();
            newForm3.ShowDialog();
            this.Dispose();
        }
    }
}
