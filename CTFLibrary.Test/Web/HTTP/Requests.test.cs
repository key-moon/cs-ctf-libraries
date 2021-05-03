using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;

using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

using Xunit;
using System.Collections.Generic;

namespace CTFLibrary.Web.Test
{
    public class HTTPTest
    {
        [Fact]
        public void GetTest()
        {
            var res = HTTP.Get("http://httpbin.org/status/200");
            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        }
        [Fact]
        public void GetStringTest()
        {
            var res = HTTP.GetString("http://httpbin.org/base64/VEVTVAo=");
            Assert.Equal("TEST\n", res);
        }
        [Fact]
        public void GetJsonTest()
        {
            var res = HTTP.GetJson<Result>("http://httpbin.org/json");
            Assert.Equal("Yours Truly", res.slideshow.author);
        }
        [Fact]
        public void GetHtmlTest()
        {
            var res = HTTP.GetHtml("http://httpbin.org/html");
            Assert.Equal("Herman Melville - Moby-Dick", res.GetElementsByTagName("h1")[0].TextContent);
        }

        [Fact]
        public void PostTest()
        {
            var res = HTTP.Post("http://httpbin.org/status/200", null);
            Assert.Equal(HttpStatusCode.OK, res.StatusCode);
        }

        [Fact]
        public void PostToGetStringTest()
        {
            var res = HTTP.PostToGetString("http://httpbin.org/status/418", null);
            Assert.Contains("teapot", res);
        }

        [Fact]
        public void PostToGetJsonTest()
        {
            var res = HTTP.PostToGetJson<AnythingResult>("http://httpbin.org/anything", new JsonContent<Content>(new Content()));
            Assert.True(res.json.ContainsKey("A"));
            Assert.Equal("B", res.json["A"]);
        }

        [Fact]
        public void PostToGetHtmlTest()
        {
            var res = HTTP.PostToGetHtml("http://httpbin.org", null);
            Assert.Equal("405 Method Not Allowed", res.Title);
        }
    }
    class Content
    {
        public string A => "B";
    }
    class AnythingResult
    {
        public Dictionary<string, string> json { get; set; }
    }

    class Result
    {
        public SlideShow slideshow { get; set; }
    }
    class SlideShow
    {
        public string author { get; set; }
        public string date { get; set; }
        public Slide[] slides { get; set; }
    }
    class Slide
    {
        public string title { get; set; }
        public string type { get; set; }
        public string[] items { get; set; }
    }
}


