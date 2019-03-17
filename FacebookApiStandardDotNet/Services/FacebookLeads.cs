using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Threading.Tasks;

namespace FacebookApiStandardDotNet.Services
{
    public class FacebookLeads
    {
        private string accesstoken = "EAAEhHh4pSEsBAKjDDsu75SMV7xMqfLZAC1fDw36pkzQtiW76D1tSZC5NeFO3s6ZBJ1OTkGtAgScBaIs9OhIO4KLCaZA577jjbzFhOCQtQT3ESZAMw36edQxftmj9GVpnpiYdj0YuPLgMXeDmLSPKk2zb0Sq5lNWk4HDSZCTqhWZB0NWjM7V8n4EplOOKA7vu54F0DxRrCsf3AZDZD";
        private string longAccesstoken = "EAAEhHh4pSEsBAJvatK9JigG4oUPTjNwmZBzaGZAIWoB6UVkSEJYSkQRkTgPo31Ajw8p4iU4OmTBZAAG55S4Yob5BTLJUrP2J2lIcAYVZB4aihb55t9DoJMxeFeZA8hd3FCNFsgb1BNeiKW0WiJNvDXUGZBLaKP5joZD";

        public string content;
        public FacebookLeads()
        {

        }

        public string GetLeadData(string leadid = "1989755784405615")
        {
            try
            {
                var client = new RestClient("https://graph.facebook.com/v3.2/" + leadid);
                var request = new RestRequest("leads", Method.GET);
                request.AddParameter("access_token", longAccesstoken);
                IRestResponse response = client.Execute(request);
                string contentData = response.Content;
                return contentData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public async Task<string> GetLeadDataAsync(string leadid = "1989755784405615")
        {
            try
            {
                var client = new RestClient("https://graph.facebook.com/v3.2/" + leadid);
                var request = new RestRequest("leads", Method.GET);
                request.AddParameter("access_token", longAccesstoken);

               client.ExecuteAsync(request,
                     response =>
                     {
                         content = response.Content;
                     });

                return content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }



        public string GetAdsLeadData(string adGroupId/*="1989755784405615"*/)
        {
            try
            {
                var client = new RestClient("https://graph.facebook.com/v3.2/" + adGroupId);
                var request = new RestRequest("leads", Method.GET);
                request.AddParameter("access_token", longAccesstoken);
                IRestResponse response = client.Execute(request);
                string content = response.Content;
                return content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        //https://graph.facebook.com/<API_VERSION>/<FORM_ID>/leads
        public string GetLeadByFormId(string formId)
        {
            try
            {
                var client = new RestClient("https://graph.facebook.com/v3.2/" + formId+"/leads");
                var request = new RestRequest(Method.GET);
                request.AddParameter("access_token", longAccesstoken);
                IRestResponse response = client.Execute(request);
                string content = response.Content;
                return content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //"https://graph.facebook.com/<API_VERSION>/<LEAD_ID>?fields=custom_disclaimer_responses"
        //Reading Custom Disclaimer Responses
        public string GetCustomDisclaimer(string formId)
        {
            try
            {
                var client = new RestClient("https://graph.facebook.com/v3.2/" + formId + "/leads?fields=custom_disclaimer_responses");
                var request = new RestRequest(Method.GET);
                request.AddParameter("access_token", longAccesstoken);
                IRestResponse response = client.Execute(request);
                string content = response.Content;
                return content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}