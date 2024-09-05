using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultJogos
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //criando variáveis
            string usuario, senha;

            //inicilizar as variáveis
            usuario = txtUsuario.Text;
            senha = txtSenha.Text;

            //validando a entrada do usuário
            if (usuario.Equals("senac") && senha.Equals("senac"))
            {
                //entrar no sistema
                frmMenuPrincipal abrir = new frmMenuPrincipal();
                abrir.Show();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.",
                    "Sistema", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }







        }
    }
}
