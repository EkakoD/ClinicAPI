using System;
using ClinicAPI.Application.Base;
using ClinicAPI.Infrastructure.Repositories;
using MediatR;

namespace ClinicAPI.Application.Category.Query.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IResponse<List<CategoriesModel>>>
    {
        private IBaseRepository _repository;
        public GetCategoriesQueryHandler(IBaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IResponse<List<CategoriesModel>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<CategoriesModel>>();
            List<CategoriesModel> categories = _repository.GetAll<CategoriesModel>("[dbo].[GetCategories]", request);
            response.Data = categories;
            response.SuccessData();
            return response;
        }
    }
}

