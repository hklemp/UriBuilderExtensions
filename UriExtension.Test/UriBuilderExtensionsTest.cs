using System;
using UriBuilderExtension;
using Xunit;

namespace UriExtension.Test
{
	public class UriBuilderExtensionsTest
    {
        [Fact]
        public void Test1()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "www.google.com";
            uriBuilder.Path = "search";

            uriBuilder.SetQueryParam("q", "query+goes+here");

            Assert.Equal("http://www.google.com/search?q=query+goes+here", uriBuilder.Uri.ToString());

        }
    }
}
