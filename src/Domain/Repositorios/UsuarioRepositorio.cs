using Aplication.Model;
using Domain.Repositorios.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DevContext _context;
        public UsuarioRepositorio(DevContext context){
            _context = context;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> ListarTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel)
        {
            await _context.Usuarios.AddAsync(usuarioModel);
            await _context.SaveChangesAsync();
            return usuarioModel;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id)
        {
            UsuarioModel usuario = await BuscarPorId(id);
            if(usuario == null)
                throw new Exception("Usuário para o ID não foi encontrado!");

            usuario.Nome = usuarioModel.Nome;
            usuario.Email = usuarioModel.Email;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public async Task<bool> Deletar(int id)
        {
            UsuarioModel usuario = await BuscarPorId(id);
            if (usuario == null)
                throw new Exception("Usuário para o ID não foi encontrado!");

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }
    }
}
