using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaPontoCego.Infrastructure.Data;

var services = new ServiceCollection(); // Cria uma lista (coleção) onde vamos registrar todas as ferramentas do sistema

services.AddDbContext<AppDbContext>(options => // Configura o Entity Framework para usar o seu contexto de banco de dados
    options.UseSqlServer("Server=localhost;Database= SISTEMA_PONTO_CEGO;Trusted_Connection=True;")); // Define que usaremos o SQL Server no computador local e o nome do banco

var provider = services.BuildServiceProvider(); // Finaliza a configuração e constrói o "provedor" que entregará os serviços prontos para o uso