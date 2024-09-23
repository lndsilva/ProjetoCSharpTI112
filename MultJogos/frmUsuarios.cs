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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenhaValida.Focus();
            }
        }

        private void txtSenhaValida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSenha.Text.Equals(txtSenhaValida.Text) && txtSenhaValida.Text.Length > 10 )
                {
                    btnCheck.Visible = true;
                    btnCadastrar.Focus();
                }
                else
                {
                    MessageBox.Show("Senha não é igual");
                    txtSenhaValida.Clear();
                    txtSenhaValida.Focus();
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }
    }
}
