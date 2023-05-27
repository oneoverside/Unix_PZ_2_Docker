using System.Globalization;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Dictionary_min.Context;

public class RedisManager
{
    private readonly IDatabase _database;

    public RedisManager(IDatabase database)
    {
        _database = database;
    }

    public async Task Set(Dictionary<string, object> dictionaryForUpdateCache)
    {
        foreach (var pair in dictionaryForUpdateCache)
        {
            await Set(pair.Key, JsonConvert.SerializeObject(pair.Value));
        }
        await _database.StringSetAsync("LAST_SYNC_DATE", DateTime.Now.ToString(CultureInfo.InvariantCulture));
    }

    public async Task Set(string key, string value)
    {
        await _database.StringSetAsync(key, value);
    }
    
    public async Task<string> Get(string key)
    {
        var result = (await _database.StringGetAsync(key)).ToString();
        return result;
    }
}