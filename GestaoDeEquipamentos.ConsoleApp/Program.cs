namespace GestaoDeEquipamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {

        TelaEquipamento telaEquipamento = new TelaEquipamento();

       while (true)
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
    }
}
