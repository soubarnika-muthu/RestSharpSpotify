/*
 * Project = Spotify API testing using RestSharp
 * Author  = Soubarnika Muthu V
 * Created Date = 21/08/2021
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Net;
using Newtonsoft.Json;

namespace RestSharpAPITesting
{
    [TestClass]
    public class SpotifyApItesting
    {
        public static string myToken = "";
        public static string userId = "";
        public static string playlistId = "";
        public static IRestResponse restResponse;
        IRestClient restclient = new RestClient();

        [TestInitialize]
        public void setup()
        {
            myToken = Utility.GetToken();
        }

        [Priority(1)]
        [TestMethod]
        //Method to get current user details
        public void CurrentUserUsingRestSharp()
        {
            //Get Url link
            string geturl = "https://api.spotify.com/v1/me";

            IRestRequest restRequest = Utility.RestRequestutility(geturl);
            restResponse = restclient.Get(restRequest);
            //AssertStatement
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            Utility.Responsemessage(restResponse);
            //deseraialization object 
            var output = JsonConvert.DeserializeObject<dynamic>(restResponse.Content);
            userId = output.id;

            System.Diagnostics.Debug.WriteLine("UserId:" + userId);
        }
        [Priority(2)]
        [TestMethod]
        //Method to get user profile
        public void UserProfileUsingRestSharp()
        {
            //GetCurrentUserUsingRestSharp();
            string getuserurl = "https://api.spotify.com/v1/users/" + userId + "/";

            IRestRequest restRequest = Utility.RestRequestutility(getuserurl);
            restResponse = restclient.Get(restRequest);

            //Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            Console.WriteLine((int)restResponse.StatusCode);
            System.Diagnostics.Debug.WriteLine(restResponse.StatusCode);
            Utility.Responsemessage(restResponse);
            //deseraialization object 
            var output = JsonConvert.DeserializeObject<dynamic>(restResponse.Content);
            userId = output.id;
            
            System.Diagnostics.Debug.WriteLine("userId:" + playlistId);


        }
        

    }
}
