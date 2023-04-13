using ShaurmaLand.Application.Services.Shaurmas.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.ShaurmaExamples;

public class UpdateShaurmaRequestDTOExample : IExamplesProvider<UpdateShaurmaRequestDTO>
{
    public UpdateShaurmaRequestDTO GetExamples()
    {
        return new UpdateShaurmaRequestDTO
        {
            Name = "Medium shaurma",
            Price = 15,
            Description = "Good shaurma",
            CaloryCount = 364
        };
    }
}
