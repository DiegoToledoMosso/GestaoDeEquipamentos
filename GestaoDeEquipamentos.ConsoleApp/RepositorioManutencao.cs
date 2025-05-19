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

    public bool EditarManutencao(int idManutencaoSelecionado, Manutencao chamadoManutencaoAtualizado)
    {
        Manutencao manutencaoSelecionada = SelecionarManutencaoPorId(idManutencaoSelecionado);

        if (manutencaoSelecionada == null)
            return false;



        manutencaoSelecionada.tituloChamado = chamadoManutencaoAtualizado.tituloChamado;
        manutencaoSelecionada.descricaoChamado = chamadoManutencaoAtualizado.descricaoChamado;
        manutencaoSelecionada.equipamentoManutencao = chamadoManutencaoAtualizado.equipamentoManutencao;
        manutencaoSelecionada.dataManutencao = chamadoManutencaoAtualizado.dataManutencao;
        

        return true;
    }

    public bool ExcluirManutencao(int idSelecionado)
    {

        for (int i = 0; i < manutencoes.Length; i++)
        {

            if (manutencoes[i] == null)
                continue;

            if (manutencoes[i].id == idSelecionado)
            {
                manutencoes[i] = null;

                return true;
            }
        }

        return false;
    }

    public Manutencao SelecionarManutencaoPorId(int idManutencaoSelecionado)
    {

        for (int i = 0; i < manutencoes.Length; i++)
        {
            Manutencao m = manutencoes[i];

            if (m == null)
                continue;

            if (m.id == idManutencaoSelecionado)
                return m;

        }

        return null;
    }

}






