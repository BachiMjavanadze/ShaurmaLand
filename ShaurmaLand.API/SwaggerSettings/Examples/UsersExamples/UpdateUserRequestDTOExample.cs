using ShaurmaLand.Application.Services.Users.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.SwaggerSettings.Examples.UsersExamples;

public class UpdateUserRequestDTOExample : IExamplesProvider<UpdateUserRequestDTO>
{
    public UpdateUserRequestDTO GetExamples()
    {
        return new UpdateUserRequestDTO
        {
            Name = "Bachi",
            LastName = "Mjavanadze",
            Email = "bachi@mail.com",
            PhoneNumber = "1234567890",
        };
    }
}
