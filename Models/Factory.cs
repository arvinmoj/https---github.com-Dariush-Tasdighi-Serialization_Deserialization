namespace Models;
public class Factory : Object
{
    public Factory() : base()
    {
    }

    public string Name { get; set; }
    public int EmployeeCount { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public string Description { get; set; }

    public string GetString(){
       	string result =
				$"{nameof(Name)}: {Name} - {nameof(EmployeeCount)}: {EmployeeCount} - {nameof(Description)}: {Description}";

			return result;
    }
}