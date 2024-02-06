using AutoMapper;
using Lojinha.Application.Requests;
using Lojinha.Domain.Entities;
using System.Collections.ObjectModel;

namespace Lojinha.Application.Mappings;

public class RequestToEntityMap : Profile
{
    public RequestToEntityMap()
    {
        #region Produto
        CreateMap<CriarProdutoRequest, Produto>()
            .AfterMap((request, entity) => entity.Id = Guid.NewGuid());

        CreateMap<EditarProdutoRequest, Produto>();
        #endregion

        #region ProdutoImagem
        CreateMap<CriarProdutoImagemRequest, ProdutoImagem>()
            .AfterMap((request, entity) => { entity.Id = Guid.NewGuid(); entity.Base64 = request.Imagem; });
        #endregion
    }
}
