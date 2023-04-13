using ShaurmaLand.Application.Services.Addresses.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.AddressesExamples;

public class AddressResponseDTOExample : IExamplesProvider<AddressResponseDTO>
{
    public AddressResponseDTO GetExamples()
    {
        return new AddressResponseDTO
        {
            Id = 1,
            City = "Batumi",
            Country = "Georgia",
            Region = "Adjara",
            Description = "Some Description",
        };
    }
}
