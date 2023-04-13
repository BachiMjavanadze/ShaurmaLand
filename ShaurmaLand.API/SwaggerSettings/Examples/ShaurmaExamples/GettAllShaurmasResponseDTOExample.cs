using ShaurmaLand.Application.Services.Shaurmas.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.ShaurmaExamples;

public class GettAllShaurmasResponseDTOExample : IExamplesProvider<ShaurmaResponseDTO[]>
{
    public ShaurmaResponseDTO[] GetExamples()
    {
        return new ShaurmaResponseDTO[]
        {
            new ShaurmaResponseDTO
            {
                Id = 1,
                Name = "King shaurma",
                Price = 28,
                Description = "Good shaurma",
                CaloryCount = 364
            },
            new ShaurmaResponseDTO
            {
                Id = 2,
                Name = "Medium shaurma",
                Price = 15,
                Description = "Good shaurma",
                CaloryCount = 150
            },
        };
    }
}
