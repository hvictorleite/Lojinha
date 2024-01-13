using AutoMapper;
using Lojinha.Application.Queries;
using Lojinha.Application.Responses;
using Lojinha.Domain.Entities;

namespace Lojinha.Application.Mappings;

public class EntityToResponseMap : Profile
{
    public EntityToResponseMap()
    {
        CreateMap<Produto, ProdutoResponse>();
        CreateMap<ProdutoImagem, ProdutoImagemResponse>();
    }
}
