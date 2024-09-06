using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MultJogos
{
    public partial class frmFuncionarios : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmFuncionarios()
        {
            InitializeComponent();
            //executando o método desabilitar campos
            desabilitarCampos();

        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisar abrir = new frmPesquisar();
            abrir.Show();
        }
        //método para desabilitar os campos e botões
        public void desabilitarCampos()
        {
            txtCodigo.Enabled = false;
            txtEndereco.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            mskCEP.Enabled = false;
            mskCPF.Enabled = false;
            mskTelefone.Enabled = false;
            cbbEstado.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
            btnCadastrar.Enabled = false;
        }
        //método para habilitar os campos e botões
        public void habilitarCampos()
        {
            txtEndereco.Enabled = true;
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            mskCEP.Enabled = true;
            mskCPF.Enabled = true;
            mskTelefone.Enabled = true;
            cbbEstado.Enabled = true;
            btnLimpar.Enabled = true;
            btnCadastrar.Enabled = true;

            txtNome.Focus();
        }

        //Método para limpar campos
        public void limparCampos()
        {
            txtCodigo.Clear();
            txtEndereco.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            mskCEP.Clear();
            mskCPF.Clear();
            mskTelefone.Clear();
            cbbEstado.Text = "";
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
            btnCadastrar.Enabled = false;
            btnNovo.Enabled = true;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnNovo.Enabled = false;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Equals("") || txtEmail.Text.Equals("")
                || txtEndereco.Text.Equals("") || txtBairro.Text.Equals("")
                || txtCidade.Text.Equals("") || cbbEstado.Text.Equals("")
                || mskCPF.Text.Equals("   .   .   -") 
                || mskTelefone.Text.Equals("     -") || mskCEP.Text.Equals("     "))
            {
                MessageBox.Show("Não deixar campos vazios.");
                
            }
            else
            {
                MessageBox.Show("Cadastrado com sucesso!!!");
                desabilitarCampos();
                limparCampos();
               
            }
        }
    }
}
