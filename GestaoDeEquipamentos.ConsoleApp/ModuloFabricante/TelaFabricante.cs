using GestaoDeEquipamentos.ConsoleApp.ModuloChamados;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante = new RepositorioFabricante();

    public RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
    public void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("Gestão do Fabricante");

        Console.WriteLine();
    }

    public char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine("1 - Cadastro de Fabricante");
        Console.WriteLine("2 - Visualizar dados do Fabricante");
        Console.WriteLine("3 - Editar dados do Fabricante");
        Console.WriteLine("4 - Excluir Fabricante");
        Console.WriteLine("5 - Cadastro de equipamentos");
        Console.WriteLine("S - Sair");


        Console.WriteLine();
        Console.WriteLine("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }

    public char TelaEscolhida()
    {
        Console.WriteLine();
        Console.WriteLine("Escolha qual opção irá seguir");
        Console.WriteLine("1 - Equipamentos");
        Console.WriteLine("2 - Manutenção");
        Console.WriteLine("1 - Fabricante");

        Console.WriteLine();
        Console.WriteLine("Digite uma opção válida: ");
        char telaEscolhida = Console.ReadLine().ToUpper()[0];

        return telaEscolhida;
    }

    public void CadastrarFabricante()
    {

        ExibirCabecalho();
        Fabricante fabricante = ObterDadosFabricante();


        repositorioFabricante.CadastrarFabricante(fabricante);

        Console.WriteLine($"\nFabricante registrado com sucesso!");
        Console.ReadLine();

    }
    public void VisualizarRegistroFabricante(bool exibirCabecalho)
    {

        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização dos Fabricantes");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10}  | {1, -15}  |  {2, -15}  |  {3, -10}   |  {4, -15}",
            "Id", "Nome", "Email", "telefone", "Quantidade de Equipamentos"
        );

        Fabricante[] fabricantes = repositorioFabricante.SelecionarFabricante();

        int quantidadeEquipamentos = 1;

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante f = fabricantes[i];

            if (f == null)
                continue;



            Console.WriteLine(
            "{0, -10}  | {1, -15}  |  {2, -15}  |  {3, -10}   |  {4, -15}",
            f.id, f.nomeFabricante, f.Email, f.Telefone, quantidadeEquipamentos
        );
            Console.ReadLine();
        }
    }
    public void ExcluirFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Exclusão de Fabricantes");

        Console.WriteLine();

        VisualizarRegistroFabricante(false);

        Console.WriteLine("Digite o id do registro do Fabricante: ");
        int idFabricanteSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(idFabricanteSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Não foi possível encontrar o registro do Fabricante selecionado.");
            Console.ReadLine();

            return;
        }

        Console.WriteLine($"\nFabricante excluído com sucesso!");
        Console.ReadLine();
    }
    public void EditarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Edição de Equipamentos");

        Console.WriteLine();

        VisualizarRegistroFabricante(false);

        Console.WriteLine("Digite o id do Fabricante que deseja editar: ");
        int idFabricanteSelecionado = Convert.ToInt32(Console.ReadLine());
        Fabricante fabricanteAtualizado = ObterDadosFabricante();

        bool conseguiuEditar = repositorioFabricante.EditarFabricante( idFabricanteSelecionado, fabricanteAtualizado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Não foi possível encontrar o registro selecionado.");
            Console.ReadLine();

            return;
        }
        Console.WriteLine($"\nFabricante editado com sucesso!");
        Console.ReadLine();
    }
    public Fabricante ObterDadosFabricante()
    {      

        Console.WriteLine("Digite o nome do Fabricante");
        string nomeFabricante = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Digite o email do Fabricante;");
        string emailFabricante = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Digite o número telefone do fabricante;");
        string telefoneFabricante = Console.ReadLine();

        Console.WriteLine();


        Fabricante fabricante = new Fabricante();
        fabricante.nomeFabricante = nomeFabricante;
        fabricante.Email = emailFabricante;
        fabricante.Telefone = telefoneFabricante;
        
        return fabricante;
    }

    public void CadastroEquipamentos()
    {
        ExibirCabecalho();
        Equipamento equipamento = ObterDados();

        repositorioEquipamento.CadastrarEquipamento(equipamento);


        Console.WriteLine($"\nEquipamento \"{equipamento.nome}\" cadastrado com sucesso!");
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
}

