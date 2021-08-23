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
           //GetUrlfor geeting user profile
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

        [Priority(3)]
        [TestMethod]
        //Method to create playlist
        public void PostCreatePlaylist()
        {
            string postUrl = "https://api.spotify.com/v1/users/" + userId + "/playlists";


            string JsonData = "{" +
                            "\"name\": \"Soubarnika Playlist\"," +
                            "\"description\": \"New playlist description\"," +
                            "\"public\":\" false\"" +
                          "}";
            IRestRequest restRequest = Utility.RestRequestutility(postUrl);

            restRequest.AddJsonBody(JsonData);
            restResponse = restclient.Post(restRequest);

            Assert.AreEqual(201, (int)restResponse.StatusCode);
            Utility.Responsemessage(restResponse);
            //deseraialization object 
            var output = JsonConvert.DeserializeObject<dynamic>(restResponse.Content);
            playlistId = output["id"];
            System.Diagnostics.Debug.WriteLine("PlaylistId:" + playlistId);
        }

        //Method to update playlist
        [Priority(4)]
        [TestMethod]
        public void U_pdatePLaylist()
        {
            //Url for PUT method
            string putUrl = "https://api.spotify.com/v1/playlists/" + playlistId + "/";
            //Json Body
            string JsonData = "{" +
                              "\"name\": \" Playlist soubarnika\"," +
                              "\"description\": \"New playlist description\"," +
                              "\"public\": false" +
                            "}";
            //Interfaces 
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(putUrl);

            restRequest.AddHeader("Authorization", "token" + myToken);
            restRequest.AddJsonBody(JsonData);
            restResponse = restClient.Put(restRequest);
            //Assertion statement
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Utility.Responsemessage(restResponse);

        }


    }
}
