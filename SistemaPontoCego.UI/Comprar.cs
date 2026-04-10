using System;
using System.Linq;
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

            // Formatação para Moeda Brasileira (R$)
            label15.Text = subtotal.ToString("C2");
            label17.Text = totalFinal.ToString("C2");

            label10.Text = qtdCamiseta.ToString();
            label11.Text = qtdCalca.ToString();
            label12.Text = qtdBermuda.ToString();
        }

        // --- Eventos dos Botões de Quantidade ---
        private void button8_Click(object sender, EventArgs e) { qtdCamiseta++; AtualizarInterface(); }
        private void button9_Click(object sender, EventArgs e) { if (qtdCamiseta > 0) qtdCamiseta--; AtualizarInterface(); }

        private void button2_Click(object sender, EventArgs e) { qtdCalca++; AtualizarInterface(); }
        private void button3_Click(object sender, EventArgs e) { if (qtdCalca > 0) qtdCalca--; AtualizarInterface(); }

        private void button5_Click(object sender, EventArgs e) { qtdBermuda++; AtualizarInterface(); }
        private void button6_Click(object sender, EventArgs e) { if (qtdBermuda > 0) qtdBermuda--; AtualizarInterface(); }

        private void button11_Click(object sender, EventArgs e)
        {
            // Fecha o carrinho e volta para a tela anterior
            this.Close();
        }

        // --- BOTÃO FINALIZAR COMPRA (CORRIGIDO) ---
        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Criamos a tela de pagamento
            Pagamento telaPagamento = new Pagamento(label17.Text);

            // 2. Escondemos TODAS as outras janelas (Produtos, Menu, etc)
            // Isso garante que nada apareça atrás do pagamento
            foreach (Form f in Application.OpenForms.Cast<Form>().ToList())
            {
                // Esconde qualquer formulário que não seja o de Pagamento que vamos abrir
                if (f != telaPagamento)
                {
                    f.Hide();
                }
            }

            // 3. Mostramos o Pagamento como Modal (ShowDialog)
            // Isso impede que o Windows foque em qualquer outra tela
            telaPagamento.ShowDialog();

            // 4. Após fechar o pagamento, fechamos esta tela de carrinho
            this.Close();
        }

        private void Comprar_Load(object sender, EventArgs e)
        {
        }
    }
}