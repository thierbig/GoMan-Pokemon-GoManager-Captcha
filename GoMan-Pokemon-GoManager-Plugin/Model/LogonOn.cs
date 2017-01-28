using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoMan.View;

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
        private static HttpClient HttpClient { get; set; }
        public static bool Login()
        {
            if (LoggedIn) return true;
            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK) return false;

            LoggedIn = true;
            return true;
        }

        private static async Task<MethodResults> InitHttpClientNLogin()
        {
            var methodResults = new MethodResults();
            if (HttpClient != null)
            {
                methodResults.Success = true;
                return methodResults;
            }

            HttpClient = new HttpClient();

            var loginKeyValuePairArray = new[]
            {
                new KeyValuePair<string, string>("u", ApplicationModel.Settings.Username),
                new KeyValuePair<string, string>("p", ApplicationModel.Settings.Password),
            };

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

            try
            {
                using (var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage1))
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
                        HttpClient = null;
                    }
                }

            }
            catch (Exception ex)
            {
                methodResults.Error = ex;
                HttpClient = null;
            }
            finally
            {
                httpRequestMessage1.Dispose();
            }

            return methodResults;
        }

        public static async Task<MethodResults> TryPing()
        {
            var methodResults = await InitHttpClientNLogin();

            if (!methodResults.Success) return methodResults;

            var pingKeyValuePairArray = new KeyValuePair<string, string>[1]
            {
                new KeyValuePair<string, string>("hwid", Hwid.FingerPrint)
            };

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
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

                    using (var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage))
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
            catch (Exception ex)
            {
                methodResults.Error = ex;
            }
            finally
            {
                httpRequestMessage.Dispose();
            }

            return methodResults;
        }

        public static async Task<MethodResults> TryLogout()
        {
            var methodResults = new MethodResults();
            if (!LoggedIn) return methodResults;
            methodResults = await InitHttpClientNLogin();
            if (!methodResults.Success) return methodResults;

            var pingKeyValuePairArray = new[]
            {
                new KeyValuePair<string, string>("hwid", Hwid.FingerPrint)
            };

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
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

                using (var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage))
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
            catch (Exception ex)
            {
                methodResults.Error = ex;
            }
            finally
            {
                httpRequestMessage.Dispose();
            }

            return methodResults;
        }
        public static async Task<MethodResults> TryUploadAccountInfo(HttpContent accountData)
        {
            var methodResults = new MethodResults();
            if (!LoggedIn) return methodResults;
            methodResults = await InitHttpClientNLogin();
            if (!methodResults.Success) return methodResults;


            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
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

                    using (var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage))
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
            catch (Exception ex)
            {
                methodResults.Error = ex;
            }
            finally
            {
                httpRequestMessage.Dispose();
            }

            return methodResults;
        }

        public static async Task<MethodResults> TryUploadPokemon(HttpContent pokemonData)
        {
            var methodResults = new MethodResults();
            if (!LoggedIn) return methodResults;
            methodResults = await InitHttpClientNLogin();
            if (!methodResults.Success) return methodResults;


            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
                new Uri("https://goman.io/api/pokemon/"))

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
                Content = pokemonData
            };
            try
            {

                using (var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage))
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
            catch (Exception ex)
            {
                methodResults.Error = ex;
            }
            finally
            {
                httpRequestMessage.Dispose();
            }

            return methodResults;
        }
    }
}