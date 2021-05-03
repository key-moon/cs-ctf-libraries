using System;
using System.Linq;
using System.Numerics;
using Xunit;

using CTFLibrary;
using System.IO;

namespace CTFLibrary.Utils.Test
{
    public class ArchiveTest
    {
        [Fact]
        public void Test()
        {
            var zip = Convert.FromBase64String("UEsDBDMAAQBjACS9o1IAAAAAIAAAAAQAAAAIAAsAdGVzdC50eHQBmQcAAgBBRQMAAIZr7dT8vtujkfUgZ8qNa7iMyGvCb4lTF74m3fU3nFeiUEsBAj8AMwABAGMAJL2jUgAAAAAgAAAABAAAAAgALwAAAAAAAAAgAAAAAAAAAHRlc3QudHh0CgAgAAAAAAABABgA9XNAWSpA1wFoN2BdKkDXAQwuqlQqQNcBAZkHAAIAQUUDAABQSwUGAAAAAAEAAQBlAAAAUQAAAAAA");
            var path = Path.GetTempFileName();
            File.WriteAllBytes(path, zip);
            var resDir = Archive.TryUnZip(path, "pass");
            Assert.NotNull(resDir);
            var contentPath = Path.Combine(resDir, "test.txt");
            Assert.True(File.Exists(contentPath));
            Assert.Equal("TEST", File.ReadAllText(contentPath));
        }
    }
}
