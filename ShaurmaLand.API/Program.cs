using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ShaurmaLand.API.Infrastructure.ErrorHandling;
using ShaurmaLand.API.Infrastructure.RequestResponseLogger;
using ShaurmaLand.Application.Mapper;
using ShaurmaLand.Application.Services.Addresses;
using ShaurmaLand.Application.Services.Orders;
using ShaurmaLand.Application.Services.Shaurmas;
using ShaurmaLand.Application.Services.Users;
using ShaurmaLand.Infrastructure;
using ShaurmaLand.Persistence.DAL;
using SwaggerSettings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger());

builder.Services.RegisterMaps();

builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IShaurmaService, ShaurmaService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddCustomSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

app.UseRequestLocalization("ka-GE", "en-US");

app.UseHttpsRedirection();

app.UseMiddleware<RequestResponseLoggerMiddleware>();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();