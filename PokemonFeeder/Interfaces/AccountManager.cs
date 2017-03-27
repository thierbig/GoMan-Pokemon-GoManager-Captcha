using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using GoManPTCAccountCreator.Model;

namespace GoManPTCAccountCreator.Interfaces
{
    public class AccountManager : IAccountManager
    {
        public IAccount Account { get; }
        public IAccountHttpClient HttpInformation { get; set; }
        public IAccountLogger Logs { get; }

        public string CurrentTask { get; set; }
        public bool TosAccepted { get; set; }
        public bool EmailVerified { get; set; }
        public AccountStatus AccountStatus { get; set; }

        public AccountManager(IAccount account)
        {
            Account = account;
            Logs = new AccountLogs();
            AccountStatus = AccountStatus.Pending;
            AccountManagerStats.IncreaseCount(AccountStatus.Pending);
        }


        public Color GetStatusColor()
        {
            switch (AccountStatus)
            {
                case AccountStatus.Running:
                    return Color.Green;
                case AccountStatus.Failed:
                    return Color.Yellow;
                case AccountStatus.Pending:
                    return Color.LightGreen;
                case AccountStatus.Created:
                    return Color.DodgerBlue;
            }

            return SystemColors.WindowText;
        }
    }

    public class AccountLogs : IAccountLogger
    {
        public event Action<object, LogModel> EventLogAdded;
        public HashSet<LogModel> Items { get; }
        public AccountLogs()
        {
            Items = new HashSet<LogModel>();
        }
        public string LastLogMessage()
        {
            lock (Items)
            {
                if (Items.Count == 0) return "";
                var log = Items.Last();
                return log?.Message ?? "";
            }
        }

        public Color LastLogColor()
        {
            lock (Items)
            {
                if (Items.Count == 0) return Color.LightGray;
                var log = Items.Last();
                return log?.GetLogColor() ?? Color.LightGray;
            }
        }

        public void Add(LogModel log)
        {
            lock (Items)
            {
                Items.Add(log);
            }

            OnEventLogAdded(log);
        }

        protected void OnEventLogAdded(LogModel log)
        {
            EventLogAdded?.Invoke(this, log);
        }
    }
    public class AccountHttpClient  : IAccountHttpClient, IDisposable
    {
        public HttpClient HttpClient { get; private set; }
        public HttpClientHandler HttpClientHandler { get; private set; }
        public GoProxy GoProxy { get; private set; }
        public string Csrf { get; set; }
        public string CaptchaId { get; set; }
        public string CaptchaResponse { get; set; }
        public string Lt { get; set; }
        public string Execution { get; set; }
        public string EventId { get; set; }

        public AccountHttpClient()
        {
            HttpClientHandler = new HttpClientHandler();
            HttpClient = new HttpClient(HttpClientHandler) {Timeout = TimeSpan.FromSeconds(10)};
        }

        public void ChangeProxy()
        {
            var proxy = ProxyHandlerSingleton.Instance.GetRandomProxy();

            var newHttpHandler = new HttpClientHandler {CookieContainer = HttpClientHandler.CookieContainer};
            HttpClient = new HttpClient(newHttpHandler);
            HttpClientHandler = newHttpHandler;

            if (proxy != null && !proxy.Address.Equals("127.0.0.1"))
            {
                HttpClientHandler.Proxy = proxy.AsWebProxy();
            }

            GoProxy = proxy;
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
            HttpClientHandler?.Dispose();
        }
    }
}
