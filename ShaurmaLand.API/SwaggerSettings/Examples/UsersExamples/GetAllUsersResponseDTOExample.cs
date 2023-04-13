using ShaurmaLand.Application.Services.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.UsersExamples;

public class GetAllUsersResponseDTOExample : IExamplesProvider<UserResponseDTO[]>
{
    public UserResponseDTO[] GetExamples()
    {
        return new UserResponseDTO[]
        {
            new UserResponseDTO
            {
                Id = 1,
                Name = "Bachi",
                LastName = "Mjavanadze",
                Email = "bachi@mail.com",
                PhoneNumber = "1234567890",
            },
            new UserResponseDTO
            {
                Id = 2,
                Name = "Niko",
                LastName = "Dgebuadze",
                Email = "niko@mail.com",
                PhoneNumber = "3234567890",
            },
        };
    }
}
