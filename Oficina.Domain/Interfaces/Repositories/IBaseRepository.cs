namespace OficinaOS.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> BuscarPorId(int id);
        Task<List<T>> Listar();
        Task<bool> Excluir(int id);
    }
}
