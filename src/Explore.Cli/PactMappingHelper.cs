// using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Newtonsoft.Json.Schema;
// using Explore.Cli.Models;
// using Namotion.Reflection;

public static class PactMappingHelper
{

    public static bool isPact(string json)
    {
        var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        if (jsonObject != null)
        {
            var schemaJson = @"{
                'description': 'A person',
                'type': 'object',
                'properties':
                {
                    'name': {'type':'string'},
                    'hobbies': {
                    'type': 'array',
                    'items': {'type':'string'}
                    }
                }
                }";
            var  schema = JsonSchema.Parse(schemaJson);
                
        }

        return false;
    }

    public static bool isPactV4(string json)
    {
        var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        if (jsonObject != null && jsonObject.ContainsKey("metadata"))
        {
            var metadata = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonObject["metadata"].ToString() ?? string.Empty);
            if (metadata != null && metadata.ContainsKey("pactSpecification"))
            {
                var pactSpecification = JsonSerializer.Deserialize<Dictionary<string, object>>(metadata["pactSpecification"].ToString() ?? string.Empty);
                if (pactSpecification != null && pactSpecification["version"] != null && pactSpecification["version"].ToString() != null)
                {
                    var version = pactSpecification["version"].ToString();
                    if (string.Equals(version, "4.0.0", StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

            }
        }

        return false;
    }
    public static bool isPactV3(string json)
    {
        var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        if (jsonObject != null && jsonObject.ContainsKey("metadata"))
        {
            var metadata = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonObject["metadata"].ToString() ?? string.Empty);
            if (metadata != null && metadata.ContainsKey("pactSpecification"))
            {
                var pactSpecification = JsonSerializer.Deserialize<Dictionary<string, object>>(metadata["pactSpecification"].ToString() ?? string.Empty);
                if (pactSpecification != null && pactSpecification["version"] != null && pactSpecification["version"].ToString() != null)
                {
                    var version = pactSpecification["version"].ToString();
                    if (string.Equals(version, "3.0.0", StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

            }
        }

        return false;
    }
    public static bool isPactV2(string json)
    {
        var jsonObject = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

        if (jsonObject != null && jsonObject.ContainsKey("metadata"))
        {
            var metadata = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonObject["metadata"].ToString() ?? string.Empty);
            if (metadata != null && metadata.ContainsKey("pactSpecification"))
            {
                var pactSpecification = JsonSerializer.Deserialize<Dictionary<string, object>>(metadata["pactSpecification"].ToString() ?? string.Empty);
                if (pactSpecification != null && pactSpecification["version"] != null && pactSpecification["version"].ToString() != null)
                {
                    var version = pactSpecification["version"].ToString();
                    if (string.Equals(version, "2.0.0", StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

            }
        }

        return false;
    }
}