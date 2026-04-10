using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Pagamento : Form
    {
        string strCon = @"Server=.\SQLEXPRESS;Database=SistemaPontoCego;Trusted_Connection=True;TrustServerCertificate=True;";
        private string _valorTotal;

        public Pagamento(string valorTotal)
        {
            InitializeComponent();
            _valorTotal = valorTotal;
            label1.Text = "Total: " + _valorTotal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                try
                {
                    string valorLimpo = _valorTotal.Replace("R$", "").Trim();
                    string sql = "INSERT INTO Vendas (Produto, Valor, DataVenda) VALUES (@prod, @val, @data)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@prod", "Venda Estilo Urbano");
                    cmd.Parameters.AddWithValue("@val", decimal.Parse(valorLimpo));
                    cmd.Parameters.AddWithValue("@data", DateTime.Now);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Venda realizada com sucesso!", "Estilo Urbano");

                    // --- BLINDAGEM DO PROCESSO ---

                    // 1. Criamos e mostramos o Gerenciador
                    Gerenciador telaAdm = new Gerenciador();
                    telaAdm.Show();

                    // 2. EM VEZ DE FECHAR, VAMOS APENAS ESCONDER TUDO
                    // Isso mantém o "fio da vida" do programa ligado
                    this.Hide();

                    // Esconde as telas que estão lá atrás
                    if (Application.OpenForms["Comprar"] != null) Application.OpenForms["Comprar"].Hide();
                    if (Application.OpenForms["Produtos"] != null) Application.OpenForms["Produtos"].Hide();
                    if (Application.OpenForms["Form1"] != null) Application.OpenForms["Form1"].Hide(); // Caso seu login seja Form1
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro técnico: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pagamento_Load(object sender, EventArgs e) { }
    }
}