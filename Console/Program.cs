using System.Text.Json;

// started message
System.Console.WriteLine("Started ... ");

// message
string message = "Hello Ser ... ";

// convert message byte
byte[] byteArray1 =
    System.Text.Encoding.UTF8.GetBytes(s: message);

// convert byte 
string convertByte = System.Text.Encoding.UTF8.GetString(byteArray1);

// write byte
System.Console.WriteLine("Write Byte: " + convertByte);

byte[] byteArray2 =
    System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(value: message);

string message2 =
    System.Text.Json.JsonSerializer.Deserialize<string>(byteArray2);

System.Console.WriteLine(message2);
System.Console.WriteLine("----------");

System.Console.WriteLine($"{byteArray1} is equal to {byteArray2}: {IsEqual(byteArray1, byteArray2)}");
System.Console.WriteLine("----------");

// json serializer options
System.Text.Json.JsonSerializerOptions
    jsonSerializerOptions = new System.Text.Json.JsonSerializerOptions
    {
        IncludeFields = true, // Default: false
        WriteIndented = true, // Default: false
        IgnoreNullValues = false, // Default: false
        IgnoreReadOnlyFields = false, // Default: false
        IgnoreReadOnlyProperties = false, // Default: false
        PropertyNameCaseInsensitive = true, // Default: false
        DictionaryKeyPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
        PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
    };

// factory models
Models.Factory factory1 =
    new Models.Factory
    {
        Name = "Iran Khodro",
        EmployeeCount = 1000,
        Description = "Hello, World!",
    };

System.Console.WriteLine(factory1.GetString());
System.Console.WriteLine("----------");

string jsonString =
    System.Text.Json.JsonSerializer.Serialize
    (value: factory1, options: jsonSerializerOptions);

System.Console.WriteLine(jsonString);
System.Console.WriteLine("----------");

// serialize factory models
Models.Factory factory2 =
    System.Text.Json.JsonSerializer.Deserialize<Models.Factory>
    (json: jsonString, options: jsonSerializerOptions);

System.Console.WriteLine(factory2.GetString());
System.Console.WriteLine("----------");

//Models.User user1 =
//	new Models.User(uname: "User", password: "12345678910");

// user models
Models.User user1 =
    new Models.User(username: "User", password: "12345678910");

user1.Description = "Hello, World!";

System.Console.WriteLine(user1.GetString());
System.Console.WriteLine("----------");

string jsonString1 =
    System.Text.Json.JsonSerializer.Serialize(value: user1, options: jsonSerializerOptions);

System.Console.WriteLine(jsonString1);
System.Console.WriteLine("----------");

// serialize user model
Models.User user2 =
    System.Text.Json.JsonSerializer.Deserialize<Models.User>(json: jsonString1, options: jsonSerializerOptions);

System.Console.WriteLine(user2.GetString());
System.Console.WriteLine("----------");

// person models
Models.Person person1 =
        new Models.Person(x: 1, y: 2, z: 3, t: 4, m: 5)
        {
            Age = 20,
            Width = 10,
            Height = 20,
            FName = "user",
            FullName = "Users",
            Description = "Hello, World!",
        };

System.Console.WriteLine(person1.GetString());
System.Console.WriteLine("----------");

string jsonString2 =
    System.Text.Json.JsonSerializer.Serialize(value: person1, options: jsonSerializerOptions);

System.Console.WriteLine(jsonString2);
System.Console.WriteLine("----------");

// serialize person models
Models.Person person2 =
    System.Text.Json.JsonSerializer.Deserialize<Models.Person>(json: jsonString2, options: jsonSerializerOptions);

System.Console.WriteLine(person2.GetString());
System.Console.WriteLine("----------");


static bool IsEqual(byte[] byteArray1, byte[] byteArray2)
{
    if (byteArray1 == byteArray2)
    {
        return true;
    }

    if ((byteArray1 == null) || (byteArray2 == null))
    {
        return false;
    }

    if (byteArray1.Length != byteArray2.Length)
    {
        return false;
    }

    for (int index = 0; index < byteArray1.Length; index++)
    {
        if (byteArray1[index] != byteArray2[index])
        {
            return false;
        }
    }

    return true;
}