using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoMan.View;
using PoGoLibrary.Exceptions;

namespace GoMan.Model
{
    public class MethodResults
    {
        public bool Success { get; set; }
        public string Data { get; set; }
        public string Html { get; set; }
        public Exception Error { get; set; }

        public override string ToString()
        {
            return $"{nameof(Success)}: {Success}, {nameof(Data)}: {Data}, {nameof(Html)}: {Html}, {nameof(Error)}: {Error?.Message}";
        }
    }

    internal class LogonOn
    {
        private static bool LoggedIn { get; set; } = false;

        public static bool Login()
        {
            if (LoggedIn) return true;
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK) return false;

            LoggedIn = true;
            return true;
        }


        public static async Task<MethodResults> TryLoginNPingAsync()
        {
            var methodResults = new MethodResults();
            var loginKeyValuePairArray = new[]
            {
                new KeyValuePair<string, string>("u", ApplicationModel.Settings.Username),
                new KeyValuePair<string, string>("p", ApplicationModel.Settings.Password),
            };

            var pingKeyValuePairArray = new KeyValuePair<string, string>[1]
            {
                new KeyValuePair<string, string>("hwid", Hwid.FingerPrint)
            };

            var httpClient = new HttpClient();

            var httpRequestMessage1 = new HttpRequestMessage(HttpMethod.Post,
                new Uri("https://goman.io/api/login/"))

            {
                Headers =
                {
                    UserAgent =
                    {
                        new ProductInfoHeaderValue("GoManPlugin", "1.0")
                    },
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("*/*")
                    }
                },
                Content = new FormUrlEncodedContent(loginKeyValuePairArray)
            };

            var httpRequestMessage2 = new HttpRequestMessage(HttpMethod.Post,
                new Uri("https://goman.io/api/ping/"))

            {
                Headers =
                {
                    UserAgent =
                    {
                        new ProductInfoHeaderValue("GoManPlugin", "1.0")
                    },
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("*/*")
                    }
                },
                Content = new FormUrlEncodedContent(pingKeyValuePairArray)
            };
            try
            {
                using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage1))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        methodResults.Html = await httpResponseMessage.Content.ReadAsStringAsync();
                        methodResults.Success = true;
                    }
                    else
                    {
                        methodResults.Error =
                            new Exception($"{(int) httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}");
                    }
                }

                if (methodResults.Success)
                {
                    using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage2))
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            methodResults.Html = await httpResponseMessage.Content.ReadAsStringAsync();
                            methodResults.Success = true;
                        }
                        else
                        {
                            methodResults.Error =
                                new Exception($"{(int)httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                methodResults.Error = ex;
            }
            finally
            {
                httpRequestMessage1.Dispose();
                httpRequestMessage2.Dispose();
            }

            return methodResults;
        }

        public static async Task<MethodResults> TryLoginNLogout()
        {
            var methodResults = new MethodResults();
            if (!LoggedIn) return methodResults;

            var loginKeyValuePairArray = new[]
            {
                new KeyValuePair<string, string>("u", ApplicationModel.Settings.Username),
                new KeyValuePair<string, string>("p", ApplicationModel.Settings.Password),
            };

            var pingKeyValuePairArray = new[]
            {
                new KeyValuePair<string, string>("hwid", Hwid.FingerPrint)
            };

            var httpClient = new HttpClient();

            var httpRequestMessage1 = new HttpRequestMessage(HttpMethod.Post,
                new Uri("https://goman.io/api/login/"))

            {
                Headers =
                {
                    UserAgent =
                    {
                        new ProductInfoHeaderValue("GoManPlugin", "1.0")
                    },
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("*/*")
                    }
                },
                Content = new FormUrlEncodedContent(loginKeyValuePairArray)
            };

            var httpRequestMessage2 = new HttpRequestMessage(HttpMethod.Post,
                new Uri("https://goman.io/api/logout/"))

            {
                Headers =
                {
                    UserAgent =
                    {
                        new ProductInfoHeaderValue("GoManPlugin", "1.0")
                    },
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("*/*")
                    }
                },
                Content = new FormUrlEncodedContent(pingKeyValuePairArray)
            };
            try
            {
                using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage1))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        methodResults.Html = await httpResponseMessage.Content.ReadAsStringAsync();
                        methodResults.Success = true;
                    }
                    else
                    {
                        methodResults.Error =
                            new Exception($"{(int)httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}");
                    }
                }

                if (methodResults.Success)
                {
                    using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage2))
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            methodResults.Html = await httpResponseMessage.Content.ReadAsStringAsync();
                            methodResults.Success = true;
                        }
                        else
                        {
                            methodResults.Error =
                                new Exception($"{(int)httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                methodResults.Error = ex;
            }
            finally
            {
                httpRequestMessage1.Dispose();
                httpRequestMessage2.Dispose();
            }

            return methodResults;
        }
        public static async Task<MethodResults> TryLoginNUploadAccountInfo(HttpContent accountData)
        {
            var methodResults = new MethodResults();
            if (!LoggedIn) return methodResults;

            var loginKeyValuePairArray = new[]
            {
                new KeyValuePair<string, string>("u", ApplicationModel.Settings.Username),
                new KeyValuePair<string, string>("p", ApplicationModel.Settings.Password),
            };

            var httpClient = new HttpClient();

            var httpRequestMessage1 = new HttpRequestMessage(HttpMethod.Post,
                new Uri("https://goman.io/api/login/"))

            {
                Headers =
                {
                    UserAgent =
                    {
                        new ProductInfoHeaderValue("GoManPlugin", "1.0")
                    },
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("*/*")
                    }
                },
                Content = new FormUrlEncodedContent(loginKeyValuePairArray)
            };

            var httpRequestMessage2 = new HttpRequestMessage(HttpMethod.Post,
                new Uri("https://goman.io/api/accounts/"))

            {
                Headers =
                {
                    UserAgent =
                    {
                        new ProductInfoHeaderValue("GoManPlugin", "1.0")
                    },
                    Accept =
                    {
                        new MediaTypeWithQualityHeaderValue("*/*")
                    }
                },
                Content = accountData
            };
            try
            {
                using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage1))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        methodResults.Html = await httpResponseMessage.Content.ReadAsStringAsync();
                        methodResults.Success = true;
                    }
                    else
                    {
                        methodResults.Error =
                            new Exception($"{(int)httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}");
                    }
                }

                if (methodResults.Success)
                {
                    using (var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage2))
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            methodResults.Html = await httpResponseMessage.Content.ReadAsStringAsync();
                            methodResults.Success = true;
                        }
                        else
                        {
                            methodResults.Error =
                                new Exception($"{(int)httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                methodResults.Error = ex;
            }
            finally
            {
                httpRequestMessage1.Dispose();
                httpRequestMessage2.Dispose();
            }

            return methodResults;
        }
    }
}