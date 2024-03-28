using OficinaOS.Domain.Entities;

namespace OficinaOS.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity, new()
    {
        Task<T> BuscarPorId(int id);
        Task<List<T>> Listar();
        Task<bool> Excluir(int id);
        void Adicionar(T entity);
        void Atualizar(T entity);
    }
}
