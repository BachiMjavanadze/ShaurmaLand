using Microsoft.AspNetCore.Mvc;
using ShaurmaLand.API.SwaggerSettings.Examples.UsersExamples;
using ShaurmaLand.Application.Services.Users;
using ShaurmaLand.Application.Services.Users.Requests;
using ShaurmaLand.Application.Services.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.Controllers.v2;
[Route("api/v{version:apiVersion}/[Controller]")]
[ApiVersion("2.0")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Retrieves all users from database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    [HttpGet("GetAllUsers")]
    [ProducesResponseType(typeof(UserResponseDTO), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, examplesProviderType: typeof(GetAllUsersResponseDTOExample))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult<List<UserResponseDTO>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _userService.GetAllAsync(cancellationToken);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    /// <summary>
    /// Retrieves user with provided id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpGet("{id}", Name = "GetAsync")]
    [ProducesResponseType(typeof(UserResponseDTO), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, examplesProviderType: typeof(UserResponseDTOExample))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult<UserResponseDTO>> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _userService.GetAsync(id, cancellationToken);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    /// <summary>
    /// Creates a user with provided id.
    /// </summary>
    /// <param name="modelDTO"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("CreateUser")]
    [ProducesResponseType(typeof(RegisterUserRequestDTO), StatusCodes.Status201Created)]
    [SwaggerResponseExample(StatusCodes.Status201Created, examplesProviderType: typeof(RegisterUserRequestDTOExample))]
    [Produces("application/json")]
    public async Task<ActionResult<int>> PostAsync([FromBody] RegisterUserRequestDTO modelDTO, CancellationToken cancellationToken)
    {
        var userId = await _userService.CreateAsync(modelDTO, cancellationToken);

        return CreatedAtRoute
        (
           routeName: "GetAsync",
           routeValues: new { id = userId },
           value: modelDTO
        );
    }

    /// <summary>
    /// Updates user with provided id and model.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="modelDTO"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateUserRequestDTO), StatusCodes.Status204NoContent)]
    [SwaggerResponseExample(StatusCodes.Status204NoContent, examplesProviderType: typeof(UpdateUserRequestDTOExample))]
    [Produces("application/json")]
    public async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateUserRequestDTO modelDTO, CancellationToken cancellationToken)
    {
        await _userService.UpdateAsync(id, modelDTO, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Deletes user by id from database.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _userService.DeleteAsync(id, cancellationToken);
        if (result == false)
        {
            return BadRequest(result);
        }

        return Ok();
    }
}
