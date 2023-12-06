using AutoMapper;
using Lojinha.Application.Commands;
using Lojinha.Domain.Entities;

namespace Lojinha.Application.Mappings;

public class CommandToEntityMap : Profile
{
    public CommandToEntityMap()
    {
        CreateMap<CriarProdutoCommand, Produto>()
            .AfterMap((command, entity) =>
            {
                entity.Id = Guid.NewGuid();
                
                if (command.Estoque != 0)
                    entity.AdicionarAoEstoque(command.Estoque);
            });
    }
}
