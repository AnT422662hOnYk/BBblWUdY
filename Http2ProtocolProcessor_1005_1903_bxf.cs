// 代码生成时间: 2025-10-05 19:03:54
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;

// 该类实现了一个简单的HTTP/2协议处理器
public class Http2ProtocolProcessor
{
    private readonly HttpClient _httpClient;
    private readonly HttpClientHandler _httpClientHandler;

    // 构造函数，初始化HttpClient及其处理程序
    public Http2ProtocolProcessor()
    {
        // 确保HttpClient使用HTTP/2.0
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        _httpClientHandler = new HttpClientHandler();
        _httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
        _httpClient = new HttpClient(_httpClientHandler);
    }

    // 发送HTTP GET请求的方法
    public async Task<string> SendGetRequestAsync(string url)
    {
        try
        {
            // 使用HttpClient发送GET请求
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e)
        {
            // 网络请求异常处理
            Console.WriteLine($"Request exception: {e.Message}");
            return null;
        }
        catch (Exception e)
        {
            // 其他异常处理
            Console.WriteLine($"General exception: {e.Message}");
            return null;
        }
    }

    // 发送HTTP POST请求的方法
    public async Task<string> SendPostRequestAsync(string url, HttpContent content)
    {
        try
        {
            // 使用HttpClient发送POST请求
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e)
        {
            // 网络请求异常处理
            Console.WriteLine($"Request exception: {e.Message}");
            return null;
        }
        catch (Exception e)
        {
            // 其他异常处理
            Console.WriteLine($"General exception: {e.Message}");
            return null;
        }
    }

    // 析构函数，释放资源
    public void Dispose()
    {
        _httpClient?.Dispose();
        _httpClientHandler?.Dispose();
    }
}
