using System.Text.Json;

namespace WebStoryFroEveryting.Services.JerseyServices
{
    public static class JerseySessionExtension
    {
        public static void SetObjectAsJson(this ISession session, string key, object value) 
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)  where T : new()
        {
            var value = session.GetString(key);
            return value == null ? new T() : JsonSerializer.Deserialize<T>(value);
        }
    }
}
