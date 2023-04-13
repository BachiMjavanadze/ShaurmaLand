using Microsoft.AspNetCore.Mvc;
using ShaurmaLand.API.SwaggerSettings.Examples.ShaurmaExamples;
using ShaurmaLand.Application.Services.Shaurmas;
using ShaurmaLand.Application.Services.Shaurmas.Requests;
using ShaurmaLand.Application.Services.Shaurmas.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.Controllers.v2;
[Route("api/v{version:apiVersion}/[Controller]")]
[ApiVersion("2.0")]
[ApiController]
public class ShaurmasController : ControllerBase
{
    private readonly IShaurmaService _shaurmaService;

    public ShaurmasController(IShaurmaService shaurmaService)
    {
        _shaurmaService = shaurmaService;
    }

    /// <summary>
    /// Retrieves all shaurmas from database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    [HttpGet("GetAllShaurmas")]
    [ProducesResponseType(typeof(ShaurmaResponseDTO), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, examplesProviderType: typeof(GettAllShaurmasResponseDTOExample))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult<List<ShaurmaResponseDTO>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _shaurmaService.GetAllAsync(cancellationToken);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    /// <summary>
    /// Retrieves shaurma with provided id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpGet("{id}", Name = "GetShaurma")]
    [ProducesResponseType(typeof(ShaurmaResponseDTO), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, examplesProviderType: typeof(ShaurmaResponseDTOExample))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult<ShaurmaResponseDTO>> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _shaurmaService.GetAsync(id, cancellationToken);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    /// <summary>
    /// Creates a shaurma with provided data from model.
    /// </summary>
    /// <param name="modelDTO"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("CreateShaurma")]
    [ProducesResponseType(typeof(CreateShaurmaRequestDTO), StatusCodes.Status201Created)]
    [SwaggerResponseExample(StatusCodes.Status201Created, examplesProviderType: typeof(CreateShaurmaRequestDTOExample))]
    [Produces("application/json")]
    public async Task<ActionResult<int>> PostAsync([FromBody] CreateShaurmaRequestDTO modelDTO, CancellationToken cancellationToken)
    {
        var pizzaId = await _shaurmaService.CreateAsync(modelDTO, cancellationToken);

        return CreatedAtRoute
        (
           routeName: "GetShaurma",
           routeValues: new { id = pizzaId },
           value: modelDTO
        );
    }

    /// <summary>
    /// Updates shaurma with provided id and model.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="modelDTO"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateShaurmaRequestDTO), StatusCodes.Status204NoContent)]
    [SwaggerResponseExample(StatusCodes.Status204NoContent, examplesProviderType: typeof(UpdateShaurmaRequestDTOExample))]
    [Produces("application/json")]
    public async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateShaurmaRequestDTO modelDTO, CancellationToken cancellationToken)
    {
        await _shaurmaService.UpdateAsync(id, modelDTO, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Deletes shaurma by id from database.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _shaurmaService.DeleteAsync(id, cancellationToken);
        if (result == false)
        {
            return BadRequest();
        }

        return Ok();
    }
}
