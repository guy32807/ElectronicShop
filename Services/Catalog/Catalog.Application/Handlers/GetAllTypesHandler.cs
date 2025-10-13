﻿using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllTypesHandler(ITypeRepository typeRepository)
        : IRequestHandler<GetAllTypesQuery, IList<TypesResponse>>
    {
        public async Task<IList<TypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typesList = await typeRepository.GetTypesAsync();
            var typesResponseList = ProductMapper.Mapper.Map<IList<TypesResponse>>(typesList);
            return typesResponseList ?? new List<TypesResponse>();
        }
    }
}
