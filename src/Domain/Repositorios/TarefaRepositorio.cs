using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Model;
using Domain.Repositorios.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly DevContext _context;
        public TarefaRepositorio(DevContext context){
            _context = context;
        }

        public async Task<List<TarefaModel>> ListarTodos()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public Task<TarefaModel> BuscarPorId(int id)
        {
            return _context.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefaModel)
        {
            throw new NotImplementedException();
        }

        public Task<TarefaModel> Atualizar(TarefaModel tarefaModel, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
