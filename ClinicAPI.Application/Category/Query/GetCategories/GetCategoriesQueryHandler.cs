using System;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Category.Query.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoriesModel>>
    {
        private IBaseRepository _repository;
        public GetCategoriesQueryHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoriesModel>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<CategoriesModel> categories = _repository.GetAll<CategoriesModel>("[dbo].[GetCategories]", request);
            return categories;
        }
    }
}

