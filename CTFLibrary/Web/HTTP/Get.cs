using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace CTFLibrary
{
    public static partial class HTTP
    {
        static HttpClient Client = new HttpClient();
        public static async Task<HttpResponseMessage> GetAsync(string endPoint) => await Client.GetAsync(endPoint);
        public static HttpResponseMessage Get(string endPoint) => GetAsync(endPoint).Result;

        public static async Task<string> GetStringAsync(string endPoint) => await (await GetAsync(endPoint)).Content.ReadAsStringAsync();
        public static string GetString(string endPoint) => GetStringAsync(endPoint).Result;

        public static async Task<T> GetJsonAsync<T>(string endPoint, JsonSerializerOptions options = null) => JsonSerializer.Deserialize<T>(await GetStringAsync(endPoint), options);
        public static T GetJson<T>(string endPoint, JsonSerializerOptions options = null) => GetJsonAsync<T>(endPoint, options).Result;

        static HtmlParser Parser = new HtmlParser();
        public static async Task<IHtmlDocument> GetHtmlAsync(string endPoint) => Parser.ParseDocument(await GetStringAsync(endPoint));
        public static IHtmlDocument GetHtml(string endPoint) => GetHtmlAsync(endPoint).Result;


        public static async Task<HttpResponseMessage> PostAsync(string endPoint, HttpContent content) => await Client.PostAsync(endPoint, content);
        public static HttpResponseMessage Post(string endPoint, HttpContent content) => PostAsync(endPoint, content).Result;

        public static async Task<string> PostToGetStringAsync(string endPoint, HttpContent content) => await (await PostAsync(endPoint, content)).Content.ReadAsStringAsync();
        public static string PostToGetString(string endPoint, HttpContent content) => PostToGetStringAsync(endPoint, content).Result;

        public static async Task<IHtmlDocument> PostToGetHtmlAsync(string endPoint, HttpContent content) => Parser.ParseDocument(await PostToGetStringAsync(endPoint, content));
        public static IHtmlDocument PostToGetHtml(string endPoint, HttpContent content) => PostToGetHtmlAsync(endPoint, content).Result;
    }
}
