using AutoMapper;
using Lojinha.Application.Commands;
using Lojinha.Domain.Entities;

namespace Lojinha.Application.Mappings;

public class RequestToEntityMap : Profile
{
    public RequestToEntityMap()
    {
        CreateMap<CriarProdutoRequest, Produto>()
            .AfterMap((request, entity) => entity.Id = Guid.NewGuid());
    }
}
