using SubYabBot_API.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SubYabBot_API
{
    interface ISubYabBot
    {
        Task<User> Login(string Captcha, string Email, string Password);
        Task<User> Register(string Captcha, string Email, string Password, string FullName);
        Task<bool> RecoverPassword(string Captcha, string Email);
        Task<Captcha> Captcha();

        Task<Upcoming> CreateUpcoming(string Title, string NickName, string TeamName, int Season = 0, int Episode = 0);
        Task<Upcoming> UpdateUpcoming(string ID, string NickName, string TeamName, int AllLines, int TranslatedLines, Requests.Upcoming.Statuses Status);
        Task<Upcoming> DeleteUpcoming(string ID);
    }
}
