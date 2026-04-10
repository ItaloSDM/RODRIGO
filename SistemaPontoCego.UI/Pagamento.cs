using System;
using System.Data.SqlClient; // ESSA LINHA TIRA O VERMELHO DO SQL
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Pagamento : Form
    {
        // Variável global da classe para armazenar o valor recebido
        private string _valorTotal;

        public Pagamento(string valorTotal)
        {
            InitializeComponent();
            _valorTotal = valorTotal; // Salva o valor que veio da outra tela
            label1.Text = "Total a Pagar: " + _valorTotal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ATENÇÃO: Troque 'SEU_COMPUTADOR\SQLEXPRESS' pelo nome do seu servidor SQL
            string strCon = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SistemaPontoCego;Integrated Security=True";

            // SQL para criar o registro da venda
            string sql = "INSERT INTO Vendas (Produto, Valor) VALUES (@prod, @val)";

            using (SqlConnection con = new SqlConnection(strCon))
            {
                try
                {
                    // Limpa o valor para o banco aceitar (remove R$ e espaços)
                    string valorLimpo = _valorTotal.Replace("R$", "").Trim();

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@prod", "Pedido Realizado");
                    cmd.Parameters.AddWithValue("@val", decimal.Parse(valorLimpo));

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pagamento Confirmado no Banco!", "Sucesso");

                    // Abre o Gerenciador e fecha esta tela
                    Gerenciador telaAdm = new Gerenciador();
                    telaAdm.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar no banco: " + ex.Message);
                }
            }
        }

        // --- Outros métodos do seu form (cliques de imagem, etc) ---
        private void pictureBox1_Click(object sender, EventArgs e) => MessageBox.Show("PIX Selecionado");
        private void pictureBox2_Click(object sender, EventArgs e) => MessageBox.Show("Boleto Selecionado");
        private void pictureBox3_Click(object sender, EventArgs e) => MessageBox.Show("Cartão Selecionado");
        private void button1_Click(object sender, EventArgs e) { new Comprar().Show(); this.Close(); }
    }
}