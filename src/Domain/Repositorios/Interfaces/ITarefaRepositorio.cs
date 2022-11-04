using Aplication.Model;

namespace Domain.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> ListarTodos();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> Adicionar(TarefaModel tarefaModel);
        Task<TarefaModel> Atualizar(TarefaModel tarefaModel, int id);
        Task<bool> Deletar(int id);
    }
}
