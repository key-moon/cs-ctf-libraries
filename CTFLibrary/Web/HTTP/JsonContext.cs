using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CTFLibrary
{
    public class JsonContent<T> : StringContent
    {
        public JsonContent(T element) : base(JsonSerializer.Serialize(element), Encoding.UTF8, "application/json") { }
    }
}
