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
    public partial class Form3 : Form
    {

        private string conn;
        private MySqlConnection connect;

        public Form3()
        {
            InitializeComponent();
            preencherdados();
        }

        public void preencherdados()
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

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios WHERE id=2", connect);
            MySqlDataReader leitor = cmd.ExecuteReader();
            if(leitor.HasRows)
            {
                leitor.Read();
                id.Text = leitor["id"].ToString();
                nome.Text = leitor["nome"].ToString();
                cep.Text = leitor["cep"].ToString();
                sexo.Text = leitor["sexo"].ToString();

            }

            if (leitor != null)
                leitor.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm2 = new Form2();
            newForm2.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form4 newForm4 = new Form4();
            newForm4.ShowDialog();
            this.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 newForm5 = new Form5();
            newForm5.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
