using Dictionary_min.Context;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary_min.Controllers;

[ApiController]
public class CacheProviderController : ControllerBase
{
    [HttpPost("SetRedis")]
    public async Task<OkResult> SetItem1([FromBody] Pair pair, [FromServices] RedisManager redis)
    {
        await redis.Set(pair.Key, pair.Value);
        return Ok();
    }
    
    [HttpPost("GetRedis")]
    public async Task<OkObjectResult> SetItem2([FromBody] string key, [FromServices] RedisManager redis)
    {
        return Ok(await redis.Get(key));
    }
    
    public class Pair
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}