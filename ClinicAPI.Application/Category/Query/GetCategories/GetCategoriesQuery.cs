using System;
using ClinicAPI.Application.Base;
using MediatR;

namespace ClinicAPI.Application.Category.Query.GetCategories
{
	public class GetCategoriesQuery : IRequest<IResponse<List<CategoriesModel>>>
	{
		//აქ თუ რამის მიხედვით მექნება დასაფილტრი
	}
}

