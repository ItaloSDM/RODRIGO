using System;
using System.Windows.Forms;
using SistemaPontoCego.UI;

namespace SistemaPontoCego.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Isso aqui configura o visual básico das janelas
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // AQUI É O MOTOR: Ele vai iniciar o programa pela sua tela de Produtos
            Application.Run(new Cadastro());
        }
    }
}
