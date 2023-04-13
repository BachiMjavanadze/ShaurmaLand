using Swashbuckle.AspNetCore.Filters;

namespace SwaggerSettings.Examples;
public class ItemDTO_Example : IExamplesProvider<ItemDTO>
{
    public ItemDTO GetExamples()
    {
        return new ItemDTO
        {
            FirstName = "John 333",
            LastName = "Doe",
            BirthDate = DateTime.Now.AddYears(-18),
            CityName = "Tbilisi",
            Gender = true,
            Identifier = "2134234234"
        };
    }
}

// TODO: delete. "ExampleOfSingleItem" class should refer to actual DTO class
public class ItemDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Identifier { get; set; }
    public bool Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string CityName { get; set; }
}
