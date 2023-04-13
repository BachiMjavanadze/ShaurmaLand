/* Swagger and API Versioning Configuration *
*
Packages for Swagger:

      Swashbuckle.AspNetCore
      Swashbuckle.AspNetCore.Filters

Packages for Versioning:

      Microsoft.AspNetCore.Mvc.Versioning
      Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer

Write this Swagger service in `Program.cs` before `var app = builder.Build()`:

      builder.Services.AddCustomSwagger();

Write this middleware in `Program.cs` into `if (app.Environment.IsDevelopment()) {|}`:

      app.UseCustomSwagger();

In the current "*.csproj" file (where the swagger scripts are located) add this:

	    <PropertyGroup>
		    <GenerateDocumentationFile>true</GenerateDocumentationFile>
		    <NoWarn>$(NoWarn);1591</NoWarn>
	    </PropertyGroup>

Put controllers into folders: `v1`, `v2`... 
Change the controllers namespaces (add suffix: v1, v2...)
Controller attributes (for every version):

      [Route("api/v{version:apiVersion}/[Controller]")]
      [ApiVersion("1.0", Deprecated = true)] // Change the first parameter according to the API version. Do not write second parameter if the version is current
      [ApiController]

Contoller's Action method attribute to show example in swagger UI. I Variant:

      [Produces("application/json")]
      [ProducesResponseType(typeof(ItemDTO), StatusCodes.Status201Created)]
      [SwaggerResponseExample(StatusCodes.Status201Created, examplesProviderType: typeof(ItemDTO_Example))]
      [HttpPost]
      public async Task<int> Post(CreatePersonRequest request) {}

Contoller's Action method attribute to show example in swagger UI. II Variant:

        /// <summary>
        /// Creates an Item.
        /// </summary>
        /// <remarks>
        /// Note that Id is not necessary. Code block shoud have 5 spaces on the left side
        ///
        ///     POST: /Item
        ///     {
        ///        "firstName":"John",
        ///        "lastName":"Doe",
        ///        "identifier":"91002011111",
        ///        "gender":true,
        ///        "birthDate":"2000-11-17",
        ///        "cityName":"London",
        ///     }
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>New Created person's Id</returns>
        /// <response code="200">Returns the newly created person's id</response>
        /// <response code="400">If the person is not valid</response>
        [ProducesResponseType(typeof(ItemDTO), StatusCodes.Status200OK)] // Firs parameter is needed to show Example
        [Produces("application/json")]
        [HttpPost]
        public async Task<int> Post(CreatePersonRequest request) {}

If we are using diiferebt versions of Action methods in the same Controller, we also need attribute: [MapToApiVersion("2.0")]. read more:

      https://github.com/rh072005/SwashbuckleAspNetVersioningShim#note-about-maptoapiversion
      https://github.com/dotnet/aspnet-api-versioning/issues/241
*/