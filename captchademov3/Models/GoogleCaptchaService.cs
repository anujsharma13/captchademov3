using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace captchademov3.Models
{
    public class GoogleCaptchaService
    {
        public virtual async Task<GoogleCaptchaRespo> verifycaptcha(string _Token)
        {
            GoogleCaptchaData data = new GoogleCaptchaData
            {
                response = _Token,
                secret = "6LezVY0dAAAAAHXWLv68LypHJd6NYloRbcgNBLeQ"
            };
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync($"https://www.google.com/recaptcha/api/siteverify?=secret{data.secret}&response={data.response}");
            var capresp = JsonConvert.DeserializeObject<GoogleCaptchaRespo>(response);
            return capresp;
        }
    }

    public class GoogleCaptchaData
    {
        public string response { get; set; }
        public string secret { get; set; }
    }
    public class GoogleCaptchaRespo
    {
        public bool success { get; set; }
        public double score { get; set; }
        public string action { get; set; }
        public DateTime challenge_ts { get; set; }
        public string hostname { get; set; }
    }
}
