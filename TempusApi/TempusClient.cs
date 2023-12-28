using System;
using System.Net.Http;

namespace TempusApi;

public class TempusClient : ITempusClient
{
    private readonly HttpClient _httpClient;

    public TempusClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
        _httpClient.BaseAddress = new Uri("https://tempus2.xyz/api/v0");
    }
}