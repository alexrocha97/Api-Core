using Aplication.Model;

namespace Domain.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> ListarTodos();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel);
        Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id);
        Task<bool> Deletar(int id);
    }
}
