using System;
using System.Collections.Generic;
using UriBuilderExtension;
using Xunit;
using System.Linq;

namespace UriExtension.Test
{
	public class UriBuilderExtensionsTest
    {
        [Fact]
		public void TestSetQueryParamSingle()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "www.google.com";
            uriBuilder.Path = "search";

            uriBuilder.SetQueryParam("q", "query+goes+here");

            Assert.Equal("http://www.google.com/search?q=query+goes+here", uriBuilder.Uri.ToString());

        }

		[Fact]
		public void TestSetQueryParamSingleWithArray()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "www.google.com";
            uriBuilder.Path = "search";

			uriBuilder.SetQueryParam("q",  new String[] {"query+goes+here","Param2"});

            Assert.Equal("http://www.google.com/search?q=query+goes+here,Param2", uriBuilder.Uri.ToString());

        }

		[Fact]
		public void TestSetQueryParamMultiple()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "www.google.com";
            uriBuilder.Path = "search";

			uriBuilder.SetQueryParam("q", "query+goes+here");
			uriBuilder.SetQueryParam("p", "and+here");

			Assert.Equal("http://www.google.com/search?q=query+goes+here&p=and+here", uriBuilder.Uri.ToString());

        }


		[Fact]
		public void TestGetQueryParamValue()
		{
			UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "www.google.com";
            uriBuilder.Path = "search";

            uriBuilder.SetQueryParam("q", "query+goes+here");
            uriBuilder.SetQueryParam("p", "and+here");

			var value = uriBuilder.GetQueryParamValue("p");

			Assert.Equal("and+here", value.First<string>());
		}

		[Fact]
		public void TestRemoveQueryParam()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "www.google.com";
            uriBuilder.Path = "search";

            uriBuilder.SetQueryParam("q", "query+goes+here");
            uriBuilder.SetQueryParam("p", "and+here");
			uriBuilder.RemoveQueryParam("q");

			Assert.Equal("http://www.google.com/search?p=and+here", uriBuilder.Uri.ToString());

        }

		[Fact]
		public void TestGetQueryParamKeys()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "www.google.com";
            uriBuilder.Path = "search";

            uriBuilder.SetQueryParam("q", "query+goes+here");
            uriBuilder.SetQueryParam("p", "and+here");

			var value = uriBuilder.GetQueryParamKeys();

			Assert.True(value.Contains("q") && value.Contains("p"));
        }


		[Fact]
		public void TestHasQueryParam()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "www.google.com";
            uriBuilder.Path = "search";

            uriBuilder.SetQueryParam("q", "query+goes+here");
            uriBuilder.SetQueryParam("p", "and+here");

			Assert.True(uriBuilder.HasQueryParam("p"));

        }
    }
}
