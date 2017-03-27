using Main_Web_Api.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Main_Web_Api.Secundary_Service
{
    public class Who_Call
    {
        private static volatile Who_Call instance;
        private static object syncRoot = new Object();
        private static List<UriApi> Apis = new List<UriApi>();

        private Who_Call() { }

        public static Who_Call Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Who_Call();
                            instance.SetApisUris();
                        }
                    }
                }

                return instance;
            }
        }

        public async Task<string> GetUrl()
        {
            if (Apis.Count == 0)
                return string.Empty;

            UriApi api = null;
            string _isAlive = ConfigurationManager.AppSettings["IsAlive_Url"].ToString();

            if (string.IsNullOrWhiteSpace(_isAlive))
                return string.Empty;

            foreach (var item in Apis.OrderBy(p => p.VisitedAmount))
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(item.Uri);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = null;

                try
                {
                    response = await client.GetAsync(_isAlive);
                }
                catch (Exception ex)
                {
                    item.isAlive = false;
                }

                if (null != response && response.IsSuccessStatusCode)
                {
                    var respond = response.Content.ReadAsAsync<bool>();
                    if (respond.Result)
                    {
                        item.VisitedAmount++;
                        api = item;
                        break;
                    }
                }
            }

            if (null == api)
                return string.Empty;

            if (Apis.Where(p => p.isAlive).Count() <= 1)
            {
                foreach (var item in Apis)
                    item.VisitedAmount = 0;
            }

            return api.Uri;
        }

        private void SetApisUris()
        {
            var result = ConfigurationManager.AppSettings["Urls_Secundary_Api"].ToString();
            if (!string.IsNullOrWhiteSpace(result))
            {
                foreach (var item in result.Split('|'))
                {
                    var _api = Apis.FirstOrDefault(a => a.Uri.Equals(item.Trim(), StringComparison.CurrentCultureIgnoreCase));
                    if (null == _api)
                    {
                        Apis.Add(new UriApi() { Uri = item.Trim(), VisitedAmount = 0, isAlive = false });
                    }
                    else
                    {
                        _api.VisitedAmount = 0;
                        _api.isAlive = false;
                    }
                }
            }
        }
    }
}
