namespace GestaoDeEquipamentos.ConsoleApp;

public class RepositorioManutencao
{
    public Manutencao[] manutencoes = new Manutencao[100];

    public int contadorManutencao = 0;
    public void CadastrarManutencao(Manutencao manutencao)
    {
        manutencoes[contadorManutencao] = manutencao;

        contadorManutencao++;
    }
    public Manutencao[] SelecionarManutencao()
    {
        return manutencoes;
    }
}

  


