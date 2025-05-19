using GestaoDeEquipamentos.ConsoleApp.ModuloChamados;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System.ComponentModel.Design;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {

        TelaEquipamento telaEquipamento = new TelaEquipamento();
        TelaChamado telaChamado = new TelaChamado();
        TelaFabricante telaFabricante = new TelaFabricante();


        while (true)
        {

            char telaEscolhida = ApresentarMenuPrincipal();


            if (telaEscolhida == '1')
            {
                char opcaoEscolhida = telaEquipamento.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;



                switch (opcaoEscolhida)
                {
                    case '1':
                        telaEquipamento.CadastrarRegistro();
                        break;

                    case '2':
                        telaEquipamento.VisualizarRegistro(true);
                        break;

                    case '3':
                        telaEquipamento.EditarRegistro();
                        break;

                    case '4':
                        telaEquipamento.ExcluirRegistro();
                        break;
                }

            }
            else if (telaEscolhida == '2')
            {
                char opcaoEscolhida = telaChamado.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaChamado.CadastrarManutencao();
                        break;

                    case '2':
                        telaChamado.VisualizarRegistroManutencao(true);
                        break;

                    case '3':
                        telaChamado.EditarChamados();
                        break;

                    case '4':
                        telaChamado.ExcluirChamados();
                        break;

                }
            }

            else if (telaEscolhida == '3')
            {
                char opcaoEscolhida = telaFabricante.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaFabricante.CadastrarFabricante();
                        break;

                    case '2':
                        telaFabricante.VisualizarRegistroFabricante(true);
                        break;

                    case '3':
                        telaFabricante.EditarFabricante();
                        break;

                    case '4':
                        telaFabricante.ExcluirFabricante();
                        break;

                    case '5':
                        telaFabricante.CadastroEquipamentos();
                        break;

                }
            }

        }
    }

    public static char ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("|              Gestão de Equipamentos              |");
        Console.WriteLine("----------------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Equipamentos");
        Console.WriteLine("2 - Controle de Chamados");
        Console.WriteLine("3 - Controle de Fabricantes");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.WriteLine("Escolha umna das opções a seguir: ");
        char opcaoEscolhida = Console.ReadLine()[0];

        return opcaoEscolhida;

    }
}

   