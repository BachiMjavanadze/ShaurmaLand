using Microsoft.AspNetCore.Mvc;
using ShaurmaLand.API.SwaggerSettings.Examples.AddressesExamples;
using ShaurmaLand.Application.Services.Addresses;
using ShaurmaLand.Application.Services.Addresses.Requests;
using ShaurmaLand.Application.Services.Addresses.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.Controllers.v2;
[Route("api/v{version:apiVersion}/[Controller]")]
[ApiVersion("2.0")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressesController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    /// <summary>
    /// Retrieves all addresses from database
    /// </summary>
    /// <param name="cancellationToken"></param>
    [HttpGet("GetAllAddresses")]
    [ProducesResponseType(typeof(AddressResponseDTO), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, examplesProviderType: typeof(GetAllAddressResponseDTOExample))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult<List<AddressResponseDTO>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _addressService.GetAllAsync(cancellationToken);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    /// <summary>
    /// Retrieves address with provided id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpGet("{id}", Name = "GetAddress")]
    [ProducesResponseType(typeof(AddressResponseDTO), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, examplesProviderType: typeof(AddressResponseDTOExample))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult<AddressResponseDTO>> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _addressService.GetAsync(id, cancellationToken);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    /// <summary>
    /// Creates Address with provided model data.
    /// </summary>
    /// <param name="modelDTO"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("CreateAddress")]
    [ProducesResponseType(typeof(CreateAddressRequestDTO), StatusCodes.Status201Created)]
    [SwaggerResponseExample(StatusCodes.Status201Created, examplesProviderType: typeof(CreateAddressRequestDTOExample))]
    [Produces("application/json")]
    public async Task<ActionResult<int>> PostAsync([FromBody] CreateAddressRequestDTO modelDTO, CancellationToken cancellationToken)
    {
        var addressId = await _addressService.CreateAsync(modelDTO, cancellationToken);

        return CreatedAtRoute
        (
           routeName: "GetAddress",
           routeValues: new { id = addressId },
           value: modelDTO
        );
    }

    /// <summary>
    /// Updates Address with provided id and model.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="modelDTO"></param>
    /// <param name="cancellationToken"></param>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateAddressRequestDTO), StatusCodes.Status204NoContent)]
    [SwaggerResponseExample(StatusCodes.Status204NoContent, examplesProviderType: typeof(UpdateAddressRequestDTOExample))]
    [Produces("application/json")]
    public async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] UpdateAddressRequestDTO modelDTO, CancellationToken cancellationToken)
    {
        await _addressService.UpdateAsync(id, modelDTO, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Deletes address by id from database.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<bool>> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _addressService.DeleteAsync(id, cancellationToken);
        if (result == false)
        {
            return BadRequest();
        }

        return Ok();
    }
}
