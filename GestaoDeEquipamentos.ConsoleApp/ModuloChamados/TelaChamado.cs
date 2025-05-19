namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamados;
public class TelaChamado
{
    public RepositorioManutencao repositorioManutencao = new RepositorioManutencao();
    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão de Equipamentos");

        Console.WriteLine();
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Manutenção de Equipamentos");
        Console.WriteLine("2 - Visualizar Chamados de Manutenção");
        Console.WriteLine("3 - Editar Chamados de Manutenção");
        Console.WriteLine("4 - Excluir Chamados de Manutenção");
        Console.WriteLine("S - Sair");

        Console.WriteLine();
        Console.WriteLine("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;

    }

    public void CadastrarManutencao()
    {

        ExibirCabecalho();
        Manutencao manutencao = ObterDadosManutencao();


        repositorioManutencao.CadastrarManutencao(manutencao);

        Console.WriteLine($"\nManutenção registrada com sucesso!");
        Console.ReadLine();

    }
    public void VisualizarRegistroManutencao(bool exibirCabecalho)
    {

        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Chamados de Manutenção");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10}  | {1, -30}  |  {2, -15}  |  {3, -10}   |  {4, -15} |  {5, -15}",
            "Id", "Titulo", "Descrição Chamado", "Equipamento", "Data de Abertura", "Dias em Aberto"
        );

        Manutencao[] manutencoes = repositorioManutencao.SelecionarManutencao();



        for (int i = 0; i < manutencoes.Length; i++)
        {
            Manutencao m = manutencoes[i];

            if (m == null)
                continue;



            Console.WriteLine(
            "{0, -10}  | {1, -30}  |  {2, -15}  |  {3, -10}   |  {4, -15}  |  {5, -15}",
            m.id, m.tituloChamado, m.descricaoChamado, m.equipamentoManutencao, m.dataManutencao.ToShortDateString(), (DateTime.Now - m.dataManutencao).Days
        );
            Console.ReadLine();
        }
    }
    public void ExcluirChamados()
    {
        ExibirCabecalho();

        Console.WriteLine("Exclusão de Chamados de Manutenção");

        Console.WriteLine();

        VisualizarRegistroManutencao(false);

        Console.WriteLine("Digite o id do registro do chamado que deseja selecionar: ");
        int idManutencaoSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        bool conseguiuExcluir = repositorioManutencao.ExcluirManutencao(idManutencaoSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }

        Console.WriteLine($"\nChamado excluído com sucesso!");
        Console.ReadLine();
    }
    public void EditarChamados()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Chamados de Manutenção");

        Console.WriteLine();

        VisualizarRegistroManutencao(false);

        Console.WriteLine("Digite o id do registro do chamado que deseja selecionar: ");
        int idManutencaoSelecionado = Convert.ToInt32(Console.ReadLine());

        Manutencao chamadoManutencaoAtualizado = ObterDadosManutencao();

        bool conseguiuEditar = repositorioManutencao.EditarManutencao(idManutencaoSelecionado, chamadoManutencaoAtualizado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }
        Console.WriteLine($"\nChamado do \"{chamadoManutencaoAtualizado.equipamentoManutencao}\" editado com sucesso!");
        Console.ReadLine();
    }
    public Manutencao ObterDadosManutencao()
    {
        Console.WriteLine("Digite o titulo do chamado");
        string tituloChamado = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Digite a descrição do chamado;");
        string descricaoChamado = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Digite qual equipamento gostaria de fazer a manutenção;");
        string equipamentoManutencao = Console.ReadLine();


        Console.WriteLine();
        Console.WriteLine("Digite o data de abertura do chamado;");
        DateTime dataManutencao = DateTime.Parse(Console.ReadLine());

        Manutencao manutencao = new Manutencao();
        manutencao.tituloChamado = tituloChamado;
        manutencao.descricaoChamado = descricaoChamado;
        manutencao.equipamentoManutencao = equipamentoManutencao;
        manutencao.dataManutencao = dataManutencao;

        return manutencao;
    }
}

