using ShaurmaLand.Application.Services.Shaurmas.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.ShaurmaExamples;

public class CreateShaurmaRequestDTOExample : IExamplesProvider<CreateShaurmaRequestDTO>
{
    public CreateShaurmaRequestDTO GetExamples()
    {
        return new CreateShaurmaRequestDTO
        {
            Name = "King Shaurma",
            Price = 15,
            Description = "Good Shaurma",
            CaloryCount = 364
        };
    }
}
