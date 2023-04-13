using ShaurmaLand.Application.Services.Users.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.UsersExamples;

public class RegisterUserRequestDTOExample : IExamplesProvider<RegisterUserRequestDTO>
{
    public RegisterUserRequestDTO GetExamples()
    {
        return new RegisterUserRequestDTO
        {
            Name = "Bachi",
            LastName = "Mjavanadze",
            Email = "bachi@mail.com",
            PhoneNumber = "1234567890",
        };
    }
}
