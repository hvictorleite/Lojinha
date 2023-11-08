using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Interfaces.Repositories;

public interface IProdutoRepository
{
    void Create(Produto produto);
    void Update(Produto produto);
    void Delete(Produto produto);
    
    IList<Produto> GetAll();
    Produto GetById(Guid id);
}