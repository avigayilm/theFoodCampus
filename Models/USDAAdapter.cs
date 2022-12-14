using RestSharp;

namespace theFoodCampus.Models
{
    public class USDAAdapter
    {
        public string Check(string ingredients, string keyword)
        {
            if (keyword == " ")
                keyword = "-";
            string Url = $"http://localhost:5202/api/usda?ingredients={ingredients}&keyword=d{keyword}";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);

            // here we have to connect to the gateway and
            //get information about the weather
            return $"Here we write the weather we got from gateway";
        }
    }
}
