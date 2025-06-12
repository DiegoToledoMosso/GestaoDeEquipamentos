using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class Chamado : EntidadeBase
{
    public int id;
    public string titulo;
    public string descricao;
    public DateTime dataAbertura;

    public Equipamento equipamento;

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Chamado chamaAtualizado = (Chamado)registroAtualizado;

        this.titulo = chamaAtualizado.titulo;
        this.descricao = chamaAtualizado.descricao;
        this.dataAbertura = chamaAtualizado.dataAbertura;
        this.equipamento = chamaAtualizado.equipamento;
        
    }
    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(titulo))
            erros += "O campo \"Título\" é obrigatório!\n";

        else if (titulo.Length < 3)
            erros += "O campo \"Título\" deve conter ao menos 3 caracteres!\n";

        if (string.IsNullOrWhiteSpace(descricao))
            erros += "O campo \"Descrição\" é obrigatório.\n";

        if (equipamento == null)
            erros += "O campo \"Equipamento\" é obrigatório.\n";

        return erros;
    }
}