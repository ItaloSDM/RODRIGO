using System;
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Pagamento : Form
    {
  
        public Pagamento(string valorTotal)
        {
            InitializeComponent();

            // Aqui  joga o valor que recebeu na label da tela de pagamento

            label1.Text = "Total a Pagar: " + valorTotal;
        }

        // Você pode deixar o Load vazio ou apagá-lo se não estiver usando
        private void Pagamento_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Método de pagamento PIX foi escolhido!", "Pagamento");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Método de pagamento Boleto Bancário foi escolhido!", "Pagamento");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Método de pagamento Cartão de Crédito foi escolhido!", "Pagamento");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  nova instância da tela de compras (carrinho)
            Comprar telaCarrinho = new Comprar();

            // Mostramos a tela do carrinho
            telaCarrinho.Show();

            //  Fechar a tela de pagamento atual
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  Exibe uma mensagem amigável de sucesso
            MessageBox.Show("Pagamento confirmado com sucesso! Obrigado pela compra.", "Sucesso");

            //  Cria a instância da tela de Produtos (Vitrine)
       
            Produtos telaProdutos = new Produtos();

            //  Mostra a vitrine
            telaProdutos.Show();

            //  Fecha a tela de pagamento atual
            this.Close();
        }
    }
}