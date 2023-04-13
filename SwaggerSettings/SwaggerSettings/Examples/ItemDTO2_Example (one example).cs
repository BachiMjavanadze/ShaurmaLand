using Swashbuckle.AspNetCore.Filters;

namespace SwaggerSettings.Examples;
public class ItemDTO2_example : IMultipleExamplesProvider<ItemDTO2>
{
    public IEnumerable<SwaggerExample<ItemDTO2>> GetExamples()
    {
        yield return SwaggerExample.Create("example 1", new ItemDTO2
        {
            FirstName = "John 222",
            LastName = "Doe",
            BirthDate = DateTime.Now.AddYears(-18),
            CityName = "Tbilisi",
            Gender = true,
            Identifier = "2134234234"
        });

        yield return SwaggerExample.Create("example 2", new ItemDTO2
        {
            FirstName = "Nini 222",
            LastName = "Giorgadze",
            BirthDate = DateTime.Now.AddYears(-18),
            CityName = "Batumi",
            Gender = true,
            Identifier = "7134114234"
        });
    }
}

// TODO: delete. "ExampleOfItemCollection" class should refer to actual DTO class
public class ItemDTO2
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Identifier { get; set; }
    public bool Gender { get; set; }
    public DateTime BirthDate { get; set; }
    public string CityName { get; set; }
}
