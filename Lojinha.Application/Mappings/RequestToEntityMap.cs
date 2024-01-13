using AutoMapper;
using Lojinha.Application.Requests;
using Lojinha.Domain.Entities;
using System.Collections.ObjectModel;

namespace Lojinha.Application.Mappings;

public class RequestToEntityMap : Profile
{
    public RequestToEntityMap()
    {
        CreateMap<CriarProdutoRequest, Produto>()
            .AfterMap((request, entity) => { entity.Id = Guid.NewGuid(); entity.Imagens = new Collection<ProdutoImagem>(); });

        CreateMap<EditarProdutoRequest, Produto>();

        CreateMap<CriarProdutoImagemRequest, ProdutoImagem>()
            .AfterMap((request, entity) => entity.Id = Guid.NewGuid());

        CreateMap<EditarProdutoImagemRequest, ProdutoImagem>();
    }
}
