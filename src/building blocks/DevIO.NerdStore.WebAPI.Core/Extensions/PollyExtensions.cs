﻿using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace DevIO.NerdStore.WebAPI.Core.Extensions;

public static class PollyExtensions
{
    public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
    {
        AsyncRetryPolicy<HttpResponseMessage> retryWaitPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(
            [
                TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(5),
                        TimeSpan.FromSeconds(10)
            ], (outcome, timespan, retryCount, context) =>
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Tentando pela {retryCount} vez!");
                Console.ForegroundColor = ConsoleColor.White;
            });

        return retryWaitPolicy;
    }
}
