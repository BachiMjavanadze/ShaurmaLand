using ShaurmaLand.Application.Services.Shaurmas.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.ShaurmaExamples;

public class ShaurmaResponseDTOExample : IExamplesProvider<ShaurmaResponseDTO>
{
    public ShaurmaResponseDTO GetExamples()
    {
        return new ShaurmaResponseDTO
        {
            Id = 1,
            Name = "Medium shaurma",
            Price = 15,
            Description = "Good shaurma",
            CaloryCount = 364
        };
    }
}
