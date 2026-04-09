using System;
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
   
    public partial class Comprar : Form
    {
        private decimal precoUnitario = 74.90m;
        private decimal valorFrete = 0.00m;

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
            decimal subtotal = (qtdCamiseta + qtdCalca + qtdBermuda) * precoUnitario;
            decimal totalFinal = subtotal + valorFrete;

           
            label15.Text = subtotal.ToString("C2");
            label17.Text = totalFinal.ToString("C2");

            label10.Text = qtdCamiseta.ToString();
            label11.Text = qtdCalca.ToString();
            label12.Text = qtdBermuda.ToString();
        }

        // --- Eventos dos Botões ---
        private void button8_Click(object sender, EventArgs e) { qtdCamiseta++; AtualizarInterface(); }
        private void button9_Click(object sender, EventArgs e) { if (qtdCamiseta > 0) qtdCamiseta--; AtualizarInterface(); }

        private void button2_Click(object sender, EventArgs e) { qtdCalca++; AtualizarInterface(); }
        private void button3_Click(object sender, EventArgs e) { if (qtdCalca > 0) qtdCalca--; AtualizarInterface(); }

        private void button5_Click(object sender, EventArgs e) { qtdBermuda++; AtualizarInterface(); }
        private void button6_Click(object sender, EventArgs e) { if (qtdBermuda > 0) qtdBermuda--; AtualizarInterface(); }

        private void button11_Click(object sender, EventArgs e)
        {
            // Fecha esta tela e volta para a que estava aberta antes (Produtos)
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Criamos a tela de pagamento passando o valor
            Pagamento telaPagamento = new Pagamento(label17.Text);

            // 2. Mostramos a tela de pagamento
            telaPagamento.Show();

            // 3. Esconder a tela (Carrinho/Comprar)
            this.Hide();

            //ver se a tela de produtos está aberta e esconder ela também
            foreach (Form f in Application.OpenForms)
            {
                // Verificar se o formulário se chama "Produtos" ou "Produtos" 
                if (f.Name == "Produtos")
                {
                    f.Hide();
                }
            }
        }
    }
}

