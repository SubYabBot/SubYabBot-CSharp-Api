using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
// using Newtonsoft.Json;
using System.Net.Http.Json;
using SubYabBot_API.Model;
using SubYabBot_API.Requests;
using SubYabBot_API.Exceptions;

namespace SubYabBot_API
{
    public class SubYabBot : ISubYabBot
    {
        public enum Methods { GET, POST, PUT, PATCH, DELETE };
        private string URL;
        private string APIKey;
        private Model.Captcha _Captcha;
        private Model.User _User;
        public SubYabBot(string APIKey, string URL = "https://api.subyabbot.com/")
        {
            this.URL = URL;
            this.APIKey = APIKey;
        }

        public async Task<Model.Captcha> Captcha()
        {
            var Response = await Query<Response>("/captcha");
            this._Captcha = Response.captcha;
            return this._Captcha;
        }

        public async Task<Model.User> Login(string Captcha, string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RecoverPassword(string Captcha, string Email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(string Captcha, string Email, string Password, string FullName)
        {
            throw new NotImplementedException();
        }

        public async Task<Model.Upcoming> CreateUpcoming(string Title, string NickName, string TeamName, int Season = 0, int Episode = 0)
        {
            var Request = new Requests.Upcoming()
            {
                title = Title,
                season = Season,
                episode = Episode,
                nickname = NickName,
                teamname = TeamName
            };
            var Url = "/upcomings";
            var Response = await Query<Response, Requests.Upcoming>(Url, Methods.POST, Request);
            return Response.upcoming;
        }
        public async Task<Model.Upcoming> UpdateUpcoming(string ID, string NickName, string TeamName, int AllLines, int TranslatedLines, Requests.Upcoming.Statuses Status)
        {
            var Request = new Requests.Upcoming()
            {
                all_lines = AllLines,
                translated_lines = TranslatedLines,
                nickname = NickName,
                teamname = TeamName,
                status = (int)Status
            };

            var Url = String.Format("/upcomings/{0}", ID);
            var Response = await Query<Response, Requests.Upcoming>(Url, Methods.PATCH, Request);
            return Response.upcoming;
        }
        public async Task<Model.Upcoming> DeleteUpcoming(string ID)
        {

            var Url = String.Format("/upcomings/{0}", ID);
            var Response = await Query<Response>(Url, Methods.DELETE);
            return Response.upcoming;
        }


        private async Task<Response> Query<T>(string URL)
        {
            return await Query<T>(URL, Methods.GET);
        }
        private async Task<Response> Query<T>(string URL, Methods Method)
        {
            return await Query<T, string>(URL, Method, null);
        }
        private async Task<Response> Query<T, Q>(string Pathname, Methods Method, IRequest Params)
        {
            string URL = String.Format("/v1/{0}{1}", this.APIKey, Pathname);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/JSON"));
                client.DefaultRequestHeaders.Add("User-Agent", "DLL");
                HttpResponseMessage Response = null;
                switch (Method)
                {
                    case Methods.GET:
                        Response = await client.GetAsync(URL);
                        break;
                    case Methods.POST:
                        Response = await client.PostAsJsonAsync<Q>(URL, (Q)Params);
                        break;
                    case Methods.PATCH:
                        var content = JsonContent.Create<Q>((Q)Params);
                        Response = await client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), URL)
                        {
                            Content = content
                        });
                        break;
                    case Methods.PUT:
                        Response = await client.PutAsJsonAsync<Q>(URL, (Q)Params);
                        break;
                    case Methods.DELETE:
                        Response = await client.DeleteAsync(URL);
                        break;
                }

                if (!Response.IsSuccessStatusCode)
                {
                    switch ((int)Response.StatusCode) {
                        case 404:
                            throw new SubYabBotNotFoundException();
                        case 401:
                            throw new SubYabBotAuthorizationException();
                        case 409:
                            throw new SubYabBotFailedException(String.Format("{0} ({1})", (int)Response.StatusCode, Response.ReasonPhrase));
                        default:
                            throw new SubYabBotException(String.Format("{0} ({1})", (int)Response.StatusCode, Response.ReasonPhrase));
                    }
                }

                
                var obj = await Response.Content.ReadFromJsonAsync(typeof(T));
                return (Response)obj;
            }
        }
    }
}
