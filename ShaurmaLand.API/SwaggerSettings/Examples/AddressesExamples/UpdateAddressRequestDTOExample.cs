using ShaurmaLand.Application.Services.Addresses.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.AddressesExamples;

public class UpdateAddressRequestDTOExample : IExamplesProvider<UpdateAddressRequestDTO>
{
    public UpdateAddressRequestDTO GetExamples()
    {
        return new UpdateAddressRequestDTO
        {
            City = "Batumi",
            Country = "Georgia",
            Region = "Adjara",
            Description = "Some Description",
        };
    }
}
