using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Comprar : Form
    {
        private decimal precoUnitario = 74.90m;
        private int qtdCamiseta = 1;
        private int qtdCalca = 1;
        private int qtdBermuda = 1;

        public Comprar()
        {
            InitializeComponent();
            AtualizarInterface();
        }

        private void AtualizarInterface()
        {
            decimal total = (qtdCamiseta + qtdCalca + qtdBermuda) * precoUnitario;

            // Certifique-se que esses nomes de labels existem no seu design
            label17.Text = total.ToString("C2");
            label10.Text = qtdCamiseta.ToString();
            label11.Text = qtdCalca.ToString();
            label12.Text = qtdBermuda.ToString();
        }

        // --- BOTÃO FINALIZAR (button1) ---
        private void button1_Click(object sender, EventArgs e)
        {
            Pagamento telaPagamento = new Pagamento(label17.Text);

            // Esconde as outras telas abertas
            foreach (Form f in Application.OpenForms.Cast<Form>().ToList())
            {
                if (f.Name != "Pagamento") f.Hide();
            }

            telaPagamento.ShowDialog();
            this.Close();
        }

        // --- CAMISETA (button8 e button9) ---
        private void button8_Click(object sender, EventArgs e) { qtdCamiseta++; AtualizarInterface(); }
        private void button9_Click(object sender, EventArgs e) { if (qtdCamiseta > 0) qtdCamiseta--; AtualizarInterface(); }

        // --- CALÇA (button2 e button3) ---
        // Adicionando estes para resolver os erros CS0103 de button2 e button3
        private void button2_Click(object sender, EventArgs e) { qtdCalca++; AtualizarInterface(); }
        private void button3_Click(object sender, EventArgs e) { if (qtdCalca > 0) qtdCalca--; AtualizarInterface(); }

        // --- BERMUDA (button5 e button6) ---
        // Adicionando estes para resolver os erros CS0103 de button5 e button6
        private void button5_Click(object sender, EventArgs e) { qtdBermuda++; AtualizarInterface(); }
        private void button6_Click(object sender, EventArgs e) { if (qtdBermuda > 0) qtdBermuda--; AtualizarInterface(); }

        // --- BOTÃO VOLTAR (button11) ---
        // Adicionando para resolver o erro de button11
        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- EVENTO DE CARREGAR TELA (Comprar_Load) ---
        // Adicionando para resolver o erro de Comprar_Load
        private void Comprar_Load(object sender, EventArgs e)
        {
            // Pode ficar vazio
        }
    }
}