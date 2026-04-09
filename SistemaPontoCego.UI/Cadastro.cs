using System;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient; 
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Cadastro : Form
    {
        private string emailCadastrado;
        private string senhaCadastrada;

        public Cadastro()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {

        }

        private void txtEmailCadastro_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e) // Método disparado ao clicar no botão de cadastro
        {
           
            string conexao = @"Data Source=SEU_SERVIDOR;Initial Catalog=SistemaPonto_Cego;Integrated Security=True";

            
            string senhaHash = "";
            using (SHA256 sha256Hash = SHA256.Create()) // Cria o motor de criptografia
            {
                // Converte o texto da TextBox em bytes e gera o cálculo matemático (Hash)
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(txtSenhaCadastro.Text));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++) // Converte os bytes em uma string legível de letras e números
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                senhaHash = builder.ToString(); 
            }

            // 3. O momento em que o C# conversa com o SQL
            using (SqlConnection conn = new SqlConnection(conexao)) // Cria a ponte de conexão
            {
                try
                {
                    conn.Open(); // Abre a "porteira" da conexão com o banco

                    // Comando SQL com "Parâmetros" (@Nome, @Email, etc) para evitar ataques de Hackers (SQL Injection)
                    string sql = "INSERT INTO Usuarios (Nome, Email, Senha, Ativo) VALUES (@Nome, @Email, @Senha, 1)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn)) // Prepara o comando para ser enviado
                    {
                        // Substitui os @Parâmetros pelos valores que o usuário digitou nas caixas de texto
                        cmd.Parameters.AddWithValue("@Nome", txtNomeCadastro.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmailCadastro.Text);
                        cmd.Parameters.AddWithValue("@Senha", senhaHash); // gravando a Hash da senha, não a senha em texto puro

                        cmd.ExecuteNonQuery(); // Executa o comando de "Insert" lá no SQL Server

                        MessageBox.Show("Usuário cadastrado com sucesso usando SHA256!"); // Alerta de sucesso
                    }
                }
                catch (Exception ex) // Caso ocorra qualquer erro (banco desligado, erro de digitação, etc)
                {
                    // Mostra exatamente qual foi o erro para facilitar o conserto
                    MessageBox.Show("Erro ao conectar no banco: " + ex.Message);
                }
            } // Ao sair do 'using', a conexão é fechada automaticamente por segurança
        }

        private void btnLogin_Click(object sender, EventArgs e) // Método disparado ao clicar no botão "Entrar"
        {
            
            string conexao = @"Data Source=NOMEDOSERVIDOR;Initial Catalog=SistemaPonto_Cego;Integrated Security=True";

          
            string senhaLoginHash = "";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Converte o texto da caixa de senha em bytes e gera o Hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(txtSenhaLogin.Text));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Transforma em texto hexadecimal
                }
                senhaLoginHash = builder.ToString(); // senha do login convertida para Hash, pronta para comparação com o banco de dados
            }

            // 3. Verificação no Banco de Dados: Onde o sistema checa se as credenciais existem
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                try
                {
                    conn.Open(); // Abre a conexão com o SQL

                    // Comando SQL que tenta selecionar o Nome do usuário onde o E-mail e a Senha coincidam
                    string sql = "SELECT Nome FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Protege contra SQL Injection substituindo os parâmetros pelos valores das caixas de texto
                        cmd.Parameters.AddWithValue("@Email", txtEmailLogin.Text);
                        cmd.Parameters.AddWithValue("@Senha", senhaLoginHash); // Comparamos o Hash gerado agora com o do banco

                        // ExecuteScalar: Executa a consulta e traz apenas uma informação (neste caso, o Nome do usuário)
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null) // Se o resultado não for nulo, significa que encontrou o usuário!
                        {
                            string nomeUsuario = resultado.ToString();
                            MessageBox.Show($"Bem-vindo, {nomeUsuario}! Login realizado com sucesso.");

                        
                        }
                        else // Se o resultado for nulo, as credenciais estão erradas
                        {
                            MessageBox.Show("E-mail ou senha incorretos.");
                        }
                    }
                }
                catch (Exception ex) // Captura falhas de conexão ou erros de rede
                {
                    MessageBox.Show("Erro técnico: " + ex.Message);
                }
            }
        }

        private void CadastrioeLogin_Load(object sender, EventArgs e)
        {

        }

        private void chkVerSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerSenha.Checked)
            {
                txtSenhaLogin.PasswordChar = '\0'; // Mostra a senha
            }
            else
            {
                txtSenhaLogin.PasswordChar = '*'; // Esconde a senha
            }
        }
        

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Se o CheckBox estiver marcado
            if (chkVerSenha2.Checked)
            {
                // '\0' é o caractere nulo, ele remove qualquer máscara e mostra o texto real
                txtSenhaCadastro.PasswordChar = '\0';
            }
            else
            {
                // Se desmarcar, volta a esconder com o asterisco (ou o caractere que preferir)
                txtSenhaCadastro.PasswordChar = '*';
            }
        }
    }
}
