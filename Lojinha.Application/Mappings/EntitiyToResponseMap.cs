using AutoMapper;
using Lojinha.Application.Queries;
using Lojinha.Domain.Entities;

namespace Lojinha.Application.Mappings;

public class EntitiyToResponseMap : Profile
{
    public EntitiyToResponseMap()
    {
        CreateMap<Produto, ProdutoResponse>();
    }
}
