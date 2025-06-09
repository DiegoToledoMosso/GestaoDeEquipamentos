
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class RepositorioFabricante : RepositorioBase;












/*{

    
    public Fabricante[] fabricantes = new Fabricante[100];

    public int contadorFabricante = 0;
    public void CadastrarFabricante(Fabricante fabricante)
    {
        fabricantes[contadorFabricante] = fabricante;

        contadorFabricante++;
    }
    public Fabricante[] SelecionarFabricante()
    {
        return fabricantes;
    }

    public bool EditarFabricante(int idFabricanteSelecionado, Fabricante fabricanteAtualizado)
    {
        Fabricante fabricanteSelecionada = SelecionarFabricantePorId(idFabricanteSelecionado);

        if (fabricanteSelecionada == null)
            return false;


        fabricanteSelecionada.nomeFabricante = fabricanteAtualizado.nomeFabricante;
        fabricanteSelecionada.Email = fabricanteAtualizado.Email;
        fabricanteSelecionada.Telefone = fabricanteAtualizado.Telefone;
        

        return true;
    }

    public bool ExcluirFabricante(int idFabricanteSelecionado)
    {

        for (int i = 0; i < fabricantes.Length; i++)
        {

            if (fabricantes[i] == null)
                continue;

            if (fabricantes[i].id == idFabricanteSelecionado)
            {
                fabricantes[i] = null;

                return true;
            }
        }

        return false;
    }

    public Fabricante SelecionarFabricantePorId(int idFabricanteSelecionado)
    {

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante f = fabricantes[i];

            if (f == null)
                continue;

            if (f.id == idFabricanteSelecionado)
                return f;

        }

        return null;
    }

}*/
