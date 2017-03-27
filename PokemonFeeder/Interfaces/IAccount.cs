using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using GoManPTCAccountCreator.Model;

namespace GoManPTCAccountCreator.Interfaces
{
    public enum AccountStatus { Pending, Running, Failed, Created }
    public interface IAccountManager
    {
        IAccount Account { get; }
        IAccountHttpClient HttpInformation { get; set; }
        IAccountLogger Logs { get; }
        AccountStatus AccountStatus { get; set; }

        bool TosAccepted { get; set; }
        bool EmailVerified { get; set; }
        string CurrentTask { get; set; }

    }
    public interface IAccount
    {
        string Username { get; }
        string Password { get; }
        string Email { get; set; }
        string Country { get; }
        string DateOfBirth { get; }
        string ScreenName { get; }
        bool PublicProfileOptIn { get; }
    }

    public interface IAccountHttpClient : IDisposable
    {
        HttpClient HttpClient { get; }
        HttpClientHandler HttpClientHandler { get; }
        GoProxy GoProxy { get; }
        string Csrf { get; set; }
        string CaptchaId { get; set; }
        string CaptchaResponse { get; set; }
        string Lt { get; set; }
        string Execution { get; set; }
        string EventId { get; set; }
        void ChangeProxy();
    }

    public interface IAccountLogger
    {
        event Action<object, LogModel> EventLogAdded;
        HashSet<LogModel> Items { get; }
        string LastLogMessage();
        Color LastLogColor();
        void Add(LogModel log);
    }
}