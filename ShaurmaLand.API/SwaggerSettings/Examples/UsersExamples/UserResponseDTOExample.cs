using ShaurmaLand.Application.Services.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.UsersExamples;

public class UserResponseDTOExample : IExamplesProvider<UserResponseDTO>
{
    public UserResponseDTO GetExamples()
    {
        return new UserResponseDTO
        {
            Id = 1,
            Name = "Bachi",
            LastName = "Mjavanadze",
            Email = "bachi@mail.com",
            PhoneNumber = "1234567890",
        };
    }
}
