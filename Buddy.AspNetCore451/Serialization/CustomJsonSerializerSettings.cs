using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Buddy.AspNetCore.Serialization
{
    public class CustomJsonSerializerSettings : JsonSerializerSettings
    {
        public CustomJsonSerializerSettings(bool camelCase, bool indented)
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat;
            DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            MissingMemberHandling = MissingMemberHandling.Ignore;

            if(camelCase)
                ContractResolver = new CamelCasePropertyNamesContractResolver();

            if (indented)
                Formatting = Newtonsoft.Json.Formatting.Indented;
        }
    }
}