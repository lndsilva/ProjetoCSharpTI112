using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MultJogos
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            buscaFuncionarios();
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
                if (txtSenha.Text.Equals(txtSenhaValida.Text) && txtSenhaValida.Text.Length > 10)
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

        //cadastrar usuarios
        public void cadastrarUsuarios(string nome, string senha, int codFunc)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbUsuarios(nome,senha,codfunc)values(@nome, @senha, @codfunc);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 30).Value = nome;
            comm.Parameters.Add("@senha", MySqlDbType.VarChar, 20).Value = senha;
            comm.Parameters.Add("@codFunc", MySqlDbType.Int32, 11).Value = codFunc;

            comm.Connection = Conexao.obterConexao();

            int res = comm.ExecuteNonQuery();

            Conexao.fecharConexao();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            cadastrarUsuarios(txtUsuario.Text, txtSenha.Text, Convert.ToInt32(cbbFuncionario.SelectedItem.ToString()));
            MessageBox.Show("Usuário cadastrado com sucesso!!!", "Sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
        //método para buscar funcionários
        public void buscaFuncionarios()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios order by nome;";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            try
            {
                DR = comm.ExecuteReader();

                while (DR.Read())
                {
                    cbbFuncionario.Items.Add(DR.GetString(1));
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao conectar o banco de dados");
            }
            Conexao.fecharConexao();

        }//método para buscar funcionários por nome e pegar o código
        public void buscaFuncionariosNome(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios where nome = @nome;";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = nome;

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            DR.Read();

            // lblMostrarCodigo.Text = DR.GetInt32(0).ToString();


            Conexao.fecharConexao();

        }

        public void buscaUsuariosFuncionarios(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select usu.nome from tbUsuarios as usu inner join tbFuncionarios as func on usu.codfunc = func.codfunc where func.nome = @func.nome;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@func.nome", MySqlDbType.VarChar, 50).Value = nome;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            DR.Read();
            try
            {
                txtUsuario.Text = DR.GetString(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Usuário não encontrado");
                txtUsuario.Clear();
                txtUsuario.Enabled = true;
                txtSenha.Enabled = true;
                txtSenhaValida.Enabled = true;
                txtUsuario.Focus();

            }

            Conexao.fecharConexao();
        }

        private void cbbFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {

            buscaFuncionariosNome(cbbFuncionario.SelectedItem.ToString());
            buscaUsuariosFuncionarios(cbbFuncionario.SelectedItem.ToString());

        }
    }
}
