using Microsoft.AspNetCore.Mvc;
using ShaurmaLand.API.SwaggerSettings.Examples.OrdersExamples;
using ShaurmaLand.Application.Services.Orders;
using ShaurmaLand.Application.Services.Orders.Requests;
using ShaurmaLand.Application.Services.Orders.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace ShaurmaLand.API.Controllers.v2;
[Route("api/v{version:apiVersion}/[Controller]")]
[ApiVersion("2.0")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Retrieves all orders from database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    [HttpGet("GetAllOrders")]
    [ProducesResponseType(typeof(OrderResponseDTO), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, examplesProviderType: typeof(GetAllOrdersResponseDTOExample))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult<List<OrderResponseDTO>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _orderService.GetAllAsync(cancellationToken);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    /// <summary>
    /// Retrieves order with provided id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    [HttpGet("{id}", Name = "GetOrder")]
    [ProducesResponseType(typeof(OrderResponseDTO), StatusCodes.Status200OK)]
    [SwaggerResponseExample(StatusCodes.Status200OK, examplesProviderType: typeof(OrderResponseDTOExample))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Produces("application/json")]
    public async Task<ActionResult<OrderResponseDTO>> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
    {
        var result = await _orderService.GetAsync(id, cancellationToken);
        if (result == null)
        {
            return BadRequest();
        }

        return Ok(result);
    }

    /// <summary>
    /// Creates order with provided model data.
    /// </summary>
    /// <param name="modelDTO"></param>
    /// <param name="cancellationToken"></param>
    [HttpPost("CreateOrder")]
    [ProducesResponseType(typeof(CreateOrderRequestDTO), StatusCodes.Status201Created)]
    [SwaggerResponseExample(StatusCodes.Status201Created, examplesProviderType: typeof(CreateOrderRequestDTOExample))]
    [Produces("application/json")]
    public async Task<ActionResult<int>> PostAsync([FromBody] CreateOrderRequestDTO modelDTO, CancellationToken cancellationToken)
    {
        var orderId = await _orderService.CreateAsync(modelDTO, cancellationToken);

        return CreatedAtRoute
        (
           routeName: "GetOrder",
           routeValues: new { id = orderId },
           value: modelDTO
        );
    }
}
