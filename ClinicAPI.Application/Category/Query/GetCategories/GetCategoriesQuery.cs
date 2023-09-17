using System;
using MediatR;

namespace ClinicAPI.Application.Category.Query.GetCategories
{
	public class GetCategoriesQuery : IRequest<List<CategoriesModel>>
	{
		//აქ თუ რამის მიხედვით მექნება დასაფილტრი
	}
}

