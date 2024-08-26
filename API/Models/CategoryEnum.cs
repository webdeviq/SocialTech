using System.Text.Json.Serialization;

namespace API.Models
{
    // [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CategoryEnum
    {
        
        REACT,
        JAVASCRIPT,
        TYPESCRIPT,
        CSHARP,
        C,
        GO,
        R,
        PYTHON,
        LISP,
        LINQ,
        ANGULAR,
        NEXT,
        DOTNET,
        MVC,
        API,
        REST,
        SOAP,
        XML,
        JSON,
        CSV,
        FLUTTER,
        
    }


}