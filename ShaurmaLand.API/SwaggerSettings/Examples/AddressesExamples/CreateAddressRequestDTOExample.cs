using ShaurmaLand.Application.Services.Addresses.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.AddressesExamples;

public class CreateAddressRequestDTOExample : IExamplesProvider<CreateAddressRequestDTO>
{
    public CreateAddressRequestDTO GetExamples()
    {
        return new CreateAddressRequestDTO
        {
            UserId = 1,
            City = "Batumi",
            Country = "Georgia",
            Region = "Adjara",
            Description = "Some Description",
        };
    }
}
