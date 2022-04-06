namespace WhereIsTheBus.TelegramBot.Telegram;

internal sealed class HandleUpdateService : IHandleUpdateService
{
    private readonly IMediator _mediator;
    private readonly ITelegramRequestRouter _router;
    private readonly ILogger<HandleUpdateService> _logger;

    public HandleUpdateService(IMediator mediator, 
                               ITelegramRequestRouter router,
                               ILogger<HandleUpdateService> logger)
    {
        _mediator = mediator;
        _router = router;
        _logger = logger;
    }

    public async Task EchoAsync(Update update)
    {
        if (update.Message is null)
        {
            return;
        }

        var query = _router.RequestFrom(update.Message!);

        if (query is null)
        {
            return;
        }

        try
        {
            await _mediator.Send(query);
        }
        catch (Exception e)
        {
            _logger.LogError("Handle error {errorMessage}", e.Message);
        }
    }
}