namespace GestaoDeEquipamentos.ConsoleApp;

// Apresentação
public class TelaEquipamento
{    

    public RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();

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

        Console.WriteLine("1 - Cadastro de Equipamento");
        Console.WriteLine("2 - Visualizar Equipamentos");
        Console.WriteLine("3 - Editar Equipamentos");
        Console.WriteLine("4 - Excluir Equipamentos");
        Console.WriteLine("5 - Manutenção de Equipamentos");
        Console.WriteLine("6 - Visualizar Chamados de Manutenção");
        Console.WriteLine("S - Sair");

        Console.WriteLine();
        Console.WriteLine("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;

    }

    public void CadastrarRegistro()
    {
        ExibirCabecalho();
        Equipamento equipamento = ObterDados();

        repositorioEquipamento.CadastrarEquipamento(equipamento);

        
        Console.WriteLine($"\nEquipamento \"{equipamento.nome}\" cadastrado com sucesso!");
        Console.ReadLine();

    }

    public void CadastrarManutencao()
    {

        ExibirCabecalho();
        Manutencao manutencao = ObterDadosManutencao();


        repositorioManutencao.CadastrarManutencao(manutencao);

        Console.WriteLine($"Manutenção registrada com sucesso!");
        Console.ReadLine();



        /* ExibirCabecalho();
        Equipamento equipamento = ObterDados();

        repositorioEquipamento.CadastrarEquipamento(equipamento);


        Console.WriteLine($"\nEquipamento \"{equipamento.nome}\" cadastrado com sucesso!");
        Console.ReadLine();*/

    }


    public void VisualizarRegistro(bool exibirCabecalho)
    {

        if ( exibirCabecalho == true ) 
           ExibirCabecalho();

        Console.WriteLine("Visualização de Equipamentos");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10}  | {1, -20}  |  {2, -15}  |  {3, -10}  |  {4, -20}  |  {5, -15}",
            "Id", "Nome", "Preço Aquisição", "Número Série", "Fabricante", "Data Fabricação"
        );

        Equipamento[] equipamentos = repositorioEquipamento.SelecionarEquipamentos();

        for ( int i = 0; i < equipamentos.Length; i++ )
        {
            Equipamento e = equipamentos[i];

            if ( e == null ) 
                continue;

            Console.WriteLine(
            "{0, -10}  | {1, -20}  |  {2, -15}  |  {3, -10}  |  {4, -20}  |  {5, -15}",
            e.id, e.nome, e.precoAquisicao.ToString("C2"), e.numeroSerie, e.fabricante, e.dataFabricacao.ToShortDateString()
        );
            Console.ReadLine();
        }
    }

    public void VisualizarRegistroManutencao(bool exibirCabecalho)
    {

        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Chamados de Manutenção");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10}  | {1, -30}  |  {2, -15}  |  {3, -10}   |  {4, -15}",
            "Id", "Titulo", "Descrição Chamado", "Equipamento", "Data de Abertura"
        );

        Manutencao[] manutencoes = repositorioManutencao.SelecionarManutencao();

        for (int i = 0; i < manutencoes.Length; i++)
        {
            Manutencao m = manutencoes[i];

            if (m == null)
                continue;

            Console.WriteLine(
            "{0, -10}  | {1, -30}  |  {2, -15}  |  {3, -10}   |  {4, -15}",
            m.id, m.tituloChamado, m.descricaoChamado, m.equipamentoManutencao, m.dataManutencao.ToShortDateString()
        );
            Console.ReadLine();
        }
    }

    public void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Equipamentos");

        Console.WriteLine();

        VisualizarRegistro(false);   

        Console.WriteLine("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32( Console.ReadLine());

        Equipamento equipamentoAtualizado = ObterDados();

        bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, equipamentoAtualizado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine ( );

            return;

        }

        Console.WriteLine($"\nEquipamento \"{equipamentoAtualizado.nome}\" editado com sucesso!");
        Console.ReadLine();

    }
    
    internal void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Exclusão de Equipamentos");

        Console.WriteLine();

        VisualizarRegistro(false);

        Console.WriteLine("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine();

            return;

        }


        Console.WriteLine($"\nEquipamento excluído com sucesso!");
        Console.ReadLine();

    }

    public Equipamento ObterDados()
    {
        Console.WriteLine("Digite o nome do equipamento");
        string nome = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Digite o preço do equipamento");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Digite o numeroSerie do equipamento");
        string numeroSerie = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Digite o fabricante do equipamento");
        string fabricante = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Digite o data de fabricacao do equipamento");
        DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

        Equipamento equipamento = new Equipamento();
        equipamento.nome = nome;
        equipamento.precoAquisicao = precoAquisicao;
        equipamento.numeroSerie = numeroSerie;
        equipamento.fabricante = fabricante;
        equipamento.dataFabricacao = dataFabricacao;

        return equipamento;
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
