using System;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Cadastro : Form
    {
        string conexao = @"Server=.\SQLEXPRESS;Database=SistemaPontoCego;Trusted_Connection=True;TrustServerCertificate=True;";

        public Cadastro()
        {
            InitializeComponent();
        }

        private void Cadastro_Load(object sender, EventArgs e) { }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSenhaCadastro.Text)) { MessageBox.Show("Digite uma senha!"); return; }

            string senhaHash = GerarHash(txtSenhaCadastro.Text);
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Usuarios (Nome, Email, Senha, Ativo) VALUES (@Nome, @Email, @Senha, 1)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", txtNomeCadastro.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmailCadastro.Text);
                        cmd.Parameters.AddWithValue("@Senha", senhaHash);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Usuário cadastrado! Entrando na loja...");

                        // Direciona para produtos
                        Produtos p = new Produtos();
                        p.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string senhaLoginHash = GerarHash(txtSenhaLogin.Text);
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT Nome FROM Usuarios WHERE Email = @Email AND Senha = @Senha";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmailLogin.Text);
                        cmd.Parameters.AddWithValue("@Senha", senhaLoginHash);
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            MessageBox.Show("Bem-vindo, " + resultado.ToString());
                            Produtos p = new Produtos();
                            p.Show();
                            this.Hide();
                        }
                        else { MessageBox.Show("Login inválido."); }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Erro: " + ex.Message); }
            }
        }

        private string GerarHash(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes) builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        // --- CORREÇÃO DO SANGRAMENTO ---
        private void chkVerSenha_CheckedChanged(object sender, EventArgs e)
        {
            txtSenhaLogin.PasswordChar = chkVerSenha.Checked ? '\0' : '*';
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Se continuar vermelho, veja o passo 2 abaixo para conferir o nome no Design
            txtSenhaCadastro.PasswordChar = ((CheckBox)sender).Checked ? '\0' : '*';
        }
    }
}