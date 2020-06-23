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
    public partial class Form1 : Form
    {

        String usuario;
        String senha;
        String usuariocorreto = "2";
        String senhacorreto = "Acesso";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuario = textBox1.Text;
            senha = textBox2.Text;

            if (usuario == usuariocorreto)
            {
                if (senha == senhacorreto)
                {
                    this.Visible = false;
                    Form3 newForm3 = new Form3();
                    newForm3.ShowDialog();
                    this.Dispose();
                }

            }
            else
            {
                MessageBox.Show("USUARIO OU SENHA INCORRETO");
            }

        }
    }
    
}
