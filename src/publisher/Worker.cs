namespace publisher;

using StackExchange.Redis;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ISubscriber pub;
    private readonly RedisChannel channel;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        ConnectionMultiplexer cache = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("CACHE_HOST") ?? "127.0.0.1");
        pub = cache.GetSubscriber();
        channel = new RedisChannel("default", RedisChannel.PatternMode.Literal);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await pub.PublishAsync(channel, Guid.NewGuid().ToString());
        }
    }
}
