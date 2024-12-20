namespace subscriber;

using StackExchange.Redis;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ISubscriber sub;
    private readonly RedisChannel channel;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        ConnectionMultiplexer cache = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("CACHE_HOST") ?? "127.0.0.1");
        sub = cache.GetSubscriber();
        channel = new RedisChannel("default", RedisChannel.PatternMode.Literal);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await sub.SubscribeAsync(channel, (channel, message) =>
        {
            _logger.LogInformation("Received message: {Message}", message.ToString());
        });
    }
}
