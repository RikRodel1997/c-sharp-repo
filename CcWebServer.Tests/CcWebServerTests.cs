using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;

namespace CcWebServer.Tests;

public class CcWebServerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CcWebServerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory
            .WithWebHostBuilder(builder =>
            {
                // This forces the server to only log Warnings or Errors
                builder.ConfigureLogging(static logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Warning);
                });
            })
            .CreateClient();
    }

    [Fact]
    public async Task HomeReturnsIndexHtml()
    {
        string url = "/";

        HttpResponseMessage response = await _client.GetAsync(url);

        string actual = await response.Content.ReadAsStringAsync();

        string expected = """
            <!DOCTYPE html>
            <html lang="en">

            <head>
                <title>Simple Web Page</title>
            </head>

            <body>
                <h1>Test Web Page</h1>
                <p>My web server served this page!</p>
            </body>

            </html>
            """;

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task IndexHtmlReturnsIndexHtml()
    {
        string url = "/index.html";

        HttpResponseMessage response = await _client.GetAsync(url);

        string actual = await response.Content.ReadAsStringAsync();

        string expected = """
            <!DOCTYPE html>
            <html lang="en">

            <head>
                <title>Simple Web Page</title>
            </head>

            <body>
                <h1>Test Web Page</h1>
                <p>My web server served this page!</p>
            </body>

            </html>
            """;

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task UnknonwReturns404()
    {
        string url = "/unknown";

        HttpResponseMessage response = await _client.GetAsync(url);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Server_IsMultiThreaded_FastRequestFinishesWhileSlowRequestIsRunning()
    {
        Task<HttpResponseMessage> slowTask = _client.GetAsync("/slow");

        Stopwatch stopwatch = Stopwatch.StartNew();
        HttpResponseMessage fastResponse = await _client.GetAsync("/");
        stopwatch.Stop();

        Assert.Equal(HttpStatusCode.OK, fastResponse.StatusCode);
        Assert.True(stopwatch.ElapsedMilliseconds < 200, "Fast request was blocked by slow request!");

        HttpResponseMessage slowResponse = await slowTask;
        Assert.Equal(HttpStatusCode.OK, slowResponse.StatusCode);
    }
}
