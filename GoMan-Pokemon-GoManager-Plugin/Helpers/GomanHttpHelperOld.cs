using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoMan.Model;
using GoMan.View;

namespace GoMan.Helpers
{
    internal class GomanWebsiteHelper
    {
        private static bool LoggedIn { get; set; } = false;
        private static HttpClient HttpClient { get; set; }
        public static bool Login()
        {
            if (LoggedIn) return true;
            var loginForm = new AuthenticationUi();
            if (loginForm.ShowDialog() != DialogResult.OK) return false;

            LoggedIn = true;
            return true;
        }
        private static async Task<MethodResult<string>> InitHttpClientNLogin()
        {
            var methodResults = new MethodResult<string>();
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
                Content = new FormUrlEncodedContent(loginKeyValuePairArray)
            };

            try
            {
                using (var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage1))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        methodResults.Data = await httpResponseMessage.Content.ReadAsStringAsync();
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

        public static async Task<MethodResult<string>> TryPing()
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
                Content = new FormUrlEncodedContent(pingKeyValuePairArray)
            };

            try
            {

                    using (var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage))
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            methodResults.Data = await httpResponseMessage.Content.ReadAsStringAsync();
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

        public static async Task<MethodResult<string>> TryLogout()
        {
            var methodResults = new MethodResult<string>();
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
                Content = new FormUrlEncodedContent(pingKeyValuePairArray)
            };
            try
            {

                using (var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        methodResults.Data = await httpResponseMessage.Content.ReadAsStringAsync();
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
        public static async Task<MethodResult<string>> TryUploadAccountInfo(HttpContent accountData)
        {
            var methodResults = new MethodResult<string>();
            if (!LoggedIn) return methodResults;
            methodResults = await InitHttpClientNLogin();
            if (!methodResults.Success) return methodResults;


            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
                new Uri("https://goman.io/api/accounts/"))

            {
                Content = accountData
            };
            try
            {

                    using (var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage))
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            methodResults.Data = await httpResponseMessage.Content.ReadAsStringAsync();
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

        public static async Task<MethodResult<string>> TryUploadPokemon(HttpContent pokemonData)
        {
            var methodResults = new MethodResult<string>();
            if (!LoggedIn) return methodResults;
            methodResults = await InitHttpClientNLogin();
            if (!methodResults.Success) return methodResults;


            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post,
                new Uri("https://goman.io/api/pokemon/"))
            {
                Content = pokemonData
            };
            try
            {

                using (var httpResponseMessage = await HttpClient.SendAsync(httpRequestMessage))
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        methodResults.Data = await httpResponseMessage.Content.ReadAsStringAsync();
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