using Microsoft.JSInterop;

namespace Gaten.Web.Tarinance.Models.Web
{
    public class Cookie
    {
        readonly CancellationTokenSource cancelToken = new CancellationTokenSource();
        readonly IJSRuntime JSRuntime;
        string expires = "";

        public Cookie(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
            ExpireDays = 7;
        }

        public async Task SetValue(string key, string value, int? days = null)
        {
            var curExp = (days != null) ? (days > 0 ? DateToUTC(days.Value) : "") : expires;
            await SetCookie($"{key}={value}; expires={curExp}; path=/");
        }

        public string GetValue(string key, string def = "")
        {
            try
            {
                var cValue = GetCookie();
                if (string.IsNullOrEmpty(cValue)) return def;

                var vals = cValue.Split(';');
                foreach (var val in vals)
                    if (!string.IsNullOrEmpty(val) && val.IndexOf('=') > 0)
                        if (val[..val.IndexOf('=')].Trim().Equals(key, StringComparison.OrdinalIgnoreCase))
                            return val[(val.IndexOf('=') + 1)..];
            }
            catch
            {

            }
            finally
            {
                
            }

            return def;
        }

        private async Task SetCookie(string value)
        {
            await JSRuntime.InvokeVoidAsync("eval", $"document.cookie = \"{value}\"");
        }

        private string GetCookie()
        {
            string result = string.Empty;
            try
            {
                var work = JSRuntime.InvokeAsync<string>("eval", $"document.cookie");
                work.AsTask().Wait();
                result = work.Result;
            }
            catch
            {
            }
            finally
            {
            }

            return result;
        }

        public int ExpireDays
        {
            set => expires = DateToUTC(value);
        }

        private static string DateToUTC(int days) => DateTime.Now.AddDays(days).ToUniversalTime().ToString("R");
    }
}
