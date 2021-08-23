/*
 * Project = Spotify API testing using RestSharp
 * Author  = Soubarnika Muthu V
 * Created Date = 21/08/2021
 */
using System;
using RestSharp;
namespace RestSharpAPITesting
{
  public  class Utility
    {
        //Method to get token 
        public static string GetToken()
        {
            string myToken = "Bearer BQDbjDJhKPRkuEWZU_qie7utf9ViAj1UpQ0l5y-7MD5tXDiJak4ywW-KGD0mDkOnfgizYWiwyCXX4ddBPqHe7Js4RbBLfCxUjCz9pamFOmiluidvbXLHgZqu_jgAMmTBCAmWcfpGN7QAlfM5PxWH9F2AzueEXdo6KRXmHLKxi6p0Bvld4WWTsGr4XDiMU5aolLgnof18eDvJiZ8RFvUF5faRG2VbvAfd8URjvVUfm3-pqgHKdaMMj3KXuuB-AGJdsouWZaeQDedhzqrOu_dPyXhFoXjs3pgexRAX3k4I";
            return myToken;
        }
        //RestRequest utility method
        public static IRestRequest RestRequestutility(string url)
        {

            IRestRequest restRequest = new RestRequest(url);

            restRequest.AddHeader("Authorization", "Token" + GetToken());

            return restRequest;
        }
        //SUccessful response method
        public static void Responsemessage(IRestResponse restResponse)
        {
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Statuscode:" + restResponse.StatusCode);
                Console.WriteLine("Response:" + restResponse.Content);
            }
            Console.WriteLine(restResponse.ErrorMessage);
            Console.WriteLine(restResponse.ErrorException);
        }

    }
}
