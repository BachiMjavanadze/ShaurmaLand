using ShaurmaLand.Application.Services.Addresses.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.AddressesExamples;

public class GetAllAddressResponseDTOExample : IExamplesProvider<AddressResponseDTO[]>
{
    public AddressResponseDTO[] GetExamples()
    {
        return new AddressResponseDTO[]
        {
            new AddressResponseDTO
            {
                Id = 1,
                City = "Batumi",
                Country = "Georgia",
                Region = "Adjara",
                Description = "Some Description",
            },
            new AddressResponseDTO
            {
                Id = 2,
                City = "Tbilisi",
                Country = "Georgia",
                Region = "Tbilisi",
                Description = "Some Description",
            }
        };
    }
}