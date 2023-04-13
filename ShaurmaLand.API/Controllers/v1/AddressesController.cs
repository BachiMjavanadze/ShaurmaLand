using Microsoft.AspNetCore.Mvc;
using ShaurmaLand.API.SwaggerSettings.Examples.AddressesExamples;
using ShaurmaLand.Application.Services.Addresses;
using ShaurmaLand.Application.Services.Addresses.Requests;
using ShaurmaLand.Application.Services.Addresses.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.Controllers.v1;
[Route("api/v{version:apiVersion}/[Controller]")]
[ApiVersion("1.0", Deprecated = true)]
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
    [HttpGet]
    public async Task<ActionResult<List<AddressResponseDTO>>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Ok(await _addressService.GetAllAsync(cancellationToken));
    }

    /// <summary>
    /// Retrieves address with provided id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpGet("{id}", Name = "GetAddress")]
    public async Task<ActionResult<AddressResponseDTO>> Get(int id, CancellationToken cancellationToken)
    {
        return Ok(await _addressService.GetAsync(id, cancellationToken));
    }

    /// <summary>
    /// Creates Address with provided model data.
    /// </summary>
    /// <param name="modelDTO"></param>
    /// <param name="cancellationToken"></param>
    //[Produces("application/json")]
    [ProducesResponseType(typeof(CreateAddressRequestDTO), StatusCodes.Status201Created)]
    [SwaggerResponseExample(StatusCodes.Status201Created, examplesProviderType: typeof(CreateAddressRequestDTOExample))]
    [HttpPost]
    public async Task<ActionResult<int>> Post([FromBody] CreateAddressRequestDTO modelDTO, CancellationToken cancellationToken)
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
    [Produces("application/json")]
    [ProducesResponseType(typeof(UpdateAddressRequestDTO), StatusCodes.Status204NoContent)]
    [SwaggerResponseExample(StatusCodes.Status204NoContent, examplesProviderType: typeof(UpdateAddressRequestDTOExample))]
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateAddressRequestDTO modelDTO, CancellationToken cancellationToken)
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
    public async Task<ActionResult<bool>> Delete(int id, CancellationToken cancellationToken)
    {
        await _addressService.DeleteAsync(id, cancellationToken);
        return Ok(true);
    }
}
