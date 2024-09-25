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
using MosaicoSolutions.ViaCep;
using MySql.Data.MySqlClient;

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
        public frmFuncionarios(string nome)
        {
            InitializeComponent();
            //executando o método desabilitar campos
            desabilitarCampos();
            txtNome.Text = nome;
            pesquisarFuncionario(txtNome.Text);
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
            this.Hide();
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
            txtNum.Enabled = false;
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
            txtNum.Enabled = true;
            mskCEP.Enabled = true;
            mskCPF.Enabled = true;
            mskTelefone.Enabled = true;
            cbbEstado.Enabled = true;
            btnLimpar.Enabled = true;
            btnCadastrar.Enabled = true;

            txtNome.Focus();
        }

        public void habilitarCamposPesquisar()
        {
            txtCodigo.Enabled = false;
            txtEndereco.Enabled = true;
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtNum.Enabled = true;
            mskCEP.Enabled = true;
            mskCPF.Enabled = true;
            mskTelefone.Enabled = true;
            cbbEstado.Enabled = true;        
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = true;
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = false;
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
            txtNum.Clear();
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

        //criando o método cadastrar funcionarios
        public int cadastrarFuncionarios()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbFuncionarios(nome,email,cpf,telCel,cep,endereco,numero,bairro,cidade,estado)values(@nome,@email,@cpf,@telCel,@cep,@endereco,@numero,@bairro,@cidade,@estado);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCPF.Text;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 10).Value = mskTelefone.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCEP.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = txtEndereco.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 5).Value = txtNum.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 100).Value = txtBairro.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 100).Value = txtCidade.Text;
            comm.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;

            comm.Connection = Conexao.obterConexao();

            int res = comm.ExecuteNonQuery();

            return res;

            Conexao.fecharConexao();

        }

        public int alterarFuncionarios(int codFunc)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbFuncionarios set nome=@nome,email=@email,cpf=@cpf,telCel=@telCel,cep=@cep,endereco=@endereco,numero=@numero,bairro=@bairro,cidade=@cidade,estado=@estado where codfunc = @codfunc;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = txtNome.Text;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = txtEmail.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = mskCPF.Text;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 10).Value = mskTelefone.Text;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = mskCEP.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = txtEndereco.Text;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 5).Value = txtNum.Text;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 100).Value = txtBairro.Text;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 100).Value = txtCidade.Text;
            comm.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = cbbEstado.Text;
            comm.Parameters.Add("@codFunc", MySqlDbType.Int32,11).Value = Convert.ToInt32(codFunc);

            comm.Connection = Conexao.obterConexao();

            int res = comm.ExecuteNonQuery();

            return res;

            Conexao.fecharConexao();

        }

        //pesquisa por nome do funcionario
        public void pesquisarFuncionario(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios where nome = @nome;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 30).Value = nome;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            DR.Read();

            txtCodigo.Text = DR.GetInt32(0).ToString();
            txtNome.Text = DR.GetString(1);
            txtEmail.Text = DR.GetString(2);
            mskCPF.Text = DR.GetString(3);
            mskTelefone.Text = DR.GetString(4);
            mskCEP.Text = DR.GetString(5);
            txtEndereco.Text = DR.GetString(6);
            txtNum.Text = DR.GetString(7);
            txtBairro.Text = DR.GetString(8);
            txtCidade.Text = DR.GetString(9);
            cbbEstado.Text = DR.GetString(10);

            Conexao.fecharConexao();

            habilitarCamposPesquisar();          

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Equals("") || txtEmail.Text.Equals("")
                || txtEndereco.Text.Equals("") || txtBairro.Text.Equals("")
                || txtCidade.Text.Equals("") || cbbEstado.Text.Equals("")
                || mskCPF.Text.Equals("   .   .   -")
                || mskTelefone.Text.Equals("     -") || mskCEP.Text.Equals("     -") || txtNum.Text.Equals(""))
            {
                MessageBox.Show("Não deixar campos vazios.");

            }
            else
            {
                if (cadastrarFuncionarios() == 1)
                {
                    MessageBox.Show("Cadastrado com sucesso!!!");
                    desabilitarCampos();
                    limparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar!!!");
                    desabilitarCampos();
                    limparCampos();
                }



            }
        }

        public void buscaCEP(string cep)
        {
            var viaCEPService = ViaCepService.Default();

            try
            {
                var endereco = viaCEPService.ObterEndereco(cep);

                txtEndereco.Text = endereco.Logradouro;
                txtBairro.Text = endereco.Bairro;
                txtCidade.Text = endereco.Localidade;
                cbbEstado.Text = endereco.UF;
            }
            catch (Exception)
            {
                MessageBox.Show("CEP não encontrado!!!");
                mskCEP.Focus();
            }
        }

        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscaCEP(mskCEP.Text);
                txtNum.Focus();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //limpando os campos preenchidos
            limparCampos();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int res = alterarFuncionarios(Convert.ToInt32(txtCodigo.Text));

            if (res == 1)
            {
                MessageBox.Show("Alterado com sucesso!!!");
                desabilitarCampos();
                limparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao alterar!!!");
            }
            
        }
    }
}

