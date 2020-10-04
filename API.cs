// Decompiled with JetBrains decompiler
// Type: AuthGG.API
// Assembly: Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 21BEF00F-328C-44A0-AD30-584899C00B25
// Assembly location: C:\Users\sucht\Downloads\axelfn.exe

using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows;

namespace AuthGG
{
  internal class API
  {
    public static void Log(string username, string action)
    {
      if (!Constants.Initialized)
      {
        int num = (int) MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      if (string.IsNullOrWhiteSpace(action))
      {
        int num = (int) MessageBox.Show("Missing log information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      string[] strArray = new string[0];
      using (WebClient webClient = new WebClient())
      {
        try
        {
          Security.Start();
          webClient.Proxy = (IWebProxy) null;
          Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection()
          {
            ["token"] = Encryption.EncryptService(Constants.Token),
            ["aid"] = Encryption.APIService(OnProgramStart.AID),
            [nameof (username)] = Encryption.APIService(username),
            ["pcuser"] = Encryption.APIService(Environment.UserName),
            ["session_id"] = Constants.IV,
            ["api_id"] = Constants.APIENCRYPTSALT,
            ["api_key"] = Constants.APIENCRYPTKEY,
            ["data"] = Encryption.APIService(action),
            ["session_key"] = Constants.Key,
            ["secret"] = Encryption.APIService(OnProgramStart.Secret),
            ["type"] = Encryption.APIService("log")
          }))).Split("|".ToCharArray());
          Security.End();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
          Process.GetCurrentProcess().Kill();
        }
      }
    }

    public static bool AIO(string AIO) => API.AIOLogin(AIO) || API.AIORegister(AIO);

    public static bool AIOLogin(string AIO)
    {
      if (!Constants.Initialized)
      {
        int num = (int) MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      if (string.IsNullOrWhiteSpace(AIO))
      {
        int num = (int) MessageBox.Show("Missing user login information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      string[] strArray1 = new string[0];
      using (WebClient webClient = new WebClient())
      {
        try
        {
          Security.Start();
          webClient.Proxy = (IWebProxy) null;
          string[] strArray2 = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection()
          {
            ["token"] = Encryption.EncryptService(Constants.Token),
            ["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
            ["aid"] = Encryption.APIService(OnProgramStart.AID),
            ["session_id"] = Constants.IV,
            ["api_id"] = Constants.APIENCRYPTSALT,
            ["api_key"] = Constants.APIENCRYPTKEY,
            ["username"] = Encryption.APIService(AIO),
            ["password"] = Encryption.APIService(AIO),
            ["hwid"] = Encryption.APIService(Constants.HWID()),
            ["session_key"] = Constants.Key,
            ["secret"] = Encryption.APIService(OnProgramStart.Secret),
            ["type"] = Encryption.APIService("login")
          }))).Split("|".ToCharArray());
          if (strArray2[0] != Constants.Token)
          {
            int num = (int) MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
            Process.GetCurrentProcess().Kill();
          }
          if (Security.MaliciousCheck(strArray2[1]))
          {
            int num = (int) MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Process.GetCurrentProcess().Kill();
          }
          if (Constants.Breached)
          {
            int num = (int) MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Process.GetCurrentProcess().Kill();
          }
          switch (strArray2[2])
          {
            case "success":
              Security.End();
              User.ID = strArray2[3];
              User.Username = strArray2[4];
              User.Password = strArray2[5];
              User.Email = strArray2[6];
              User.HWID = strArray2[7];
              User.UserVariable = strArray2[8];
              User.Rank = strArray2[9];
              User.IP = strArray2[10];
              User.Expiry = strArray2[11];
              User.LastLogin = strArray2[12];
              User.RegisterDate = strArray2[13];
              string str1 = strArray2[14];
              char[] chArray1 = new char[1]{ '~' };
              foreach (string str2 in str1.Split(chArray1))
              {
                char[] chArray2 = new char[1]{ '^' };
                string[] strArray3 = str2.Split(chArray2);
                try
                {
                  App.Variables.Add(strArray3[0], strArray3[1]);
                }
                catch
                {
                }
              }
              return true;
            case "invalid_details":
              Security.End();
              return false;
            case "time_expired":
              int num1 = (int) MessageBox.Show("Your subscription has expired!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
            case "hwid_updated":
              int num2 = (int) MessageBox.Show("New machine has been binded, re-open the application!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
            case "invalid_hwid":
              int num3 = (int) MessageBox.Show("This user is binded to another computer, please contact support!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
          Security.End();
          Process.GetCurrentProcess().Kill();
        }
        return false;
      }
    }

    public static bool AIORegister(string AIO)
    {
      if (!Constants.Initialized)
      {
        int num = (int) MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Security.End();
        Process.GetCurrentProcess().Kill();
      }
      if (string.IsNullOrWhiteSpace(AIO))
      {
        int num = (int) MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      string[] strArray1 = new string[0];
      using (WebClient webClient = new WebClient())
      {
        try
        {
          Security.Start();
          webClient.Proxy = (IWebProxy) null;
          string[] strArray2 = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection()
          {
            ["token"] = Encryption.EncryptService(Constants.Token),
            ["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
            ["aid"] = Encryption.APIService(OnProgramStart.AID),
            ["session_id"] = Constants.IV,
            ["api_id"] = Constants.APIENCRYPTSALT,
            ["api_key"] = Constants.APIENCRYPTKEY,
            ["session_key"] = Constants.Key,
            ["secret"] = Encryption.APIService(OnProgramStart.Secret),
            ["type"] = Encryption.APIService("register"),
            ["username"] = Encryption.APIService(AIO),
            ["password"] = Encryption.APIService(AIO),
            ["email"] = Encryption.APIService(AIO),
            ["license"] = Encryption.APIService(AIO),
            ["hwid"] = Encryption.APIService(Constants.HWID())
          }))).Split("|".ToCharArray());
          if (strArray2[0] != Constants.Token)
          {
            int num = (int) MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
            Security.End();
            Process.GetCurrentProcess().Kill();
          }
          if (Security.MaliciousCheck(strArray2[1]))
          {
            int num = (int) MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Process.GetCurrentProcess().Kill();
          }
          if (Constants.Breached)
          {
            int num = (int) MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Process.GetCurrentProcess().Kill();
          }
          Security.End();
          switch (strArray2[2])
          {
            case "success":
              return true;
            case "error":
              return false;
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
          Process.GetCurrentProcess().Kill();
        }
        return false;
      }
    }

    public static bool Login(string username, string password)
    {
      if (!Constants.Initialized)
      {
        int num = (int) MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
      {
        int num = (int) MessageBox.Show("Missing user login information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      string[] strArray1 = new string[0];
      using (WebClient webClient = new WebClient())
      {
        try
        {
          Security.Start();
          webClient.Proxy = (IWebProxy) null;
          string[] strArray2 = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection()
          {
            ["token"] = Encryption.EncryptService(Constants.Token),
            ["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
            ["aid"] = Encryption.APIService(OnProgramStart.AID),
            ["session_id"] = Constants.IV,
            ["api_id"] = Constants.APIENCRYPTSALT,
            ["api_key"] = Constants.APIENCRYPTKEY,
            [nameof (username)] = Encryption.APIService(username),
            [nameof (password)] = Encryption.APIService(password),
            ["hwid"] = Encryption.APIService(Constants.HWID()),
            ["session_key"] = Constants.Key,
            ["secret"] = Encryption.APIService(OnProgramStart.Secret),
            ["type"] = Encryption.APIService("login")
          }))).Split("|".ToCharArray());
          if (strArray2[0] != Constants.Token)
          {
            int num = (int) MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
            Process.GetCurrentProcess().Kill();
          }
          if (Security.MaliciousCheck(strArray2[1]))
          {
            int num = (int) MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Process.GetCurrentProcess().Kill();
          }
          if (Constants.Breached)
          {
            int num = (int) MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Process.GetCurrentProcess().Kill();
          }
          switch (strArray2[2])
          {
            case "success":
              User.ID = strArray2[3];
              User.Username = strArray2[4];
              User.Password = strArray2[5];
              User.Email = strArray2[6];
              User.HWID = strArray2[7];
              User.UserVariable = strArray2[8];
              User.Rank = strArray2[9];
              User.IP = strArray2[10];
              User.Expiry = strArray2[11];
              User.LastLogin = strArray2[12];
              User.RegisterDate = strArray2[13];
              string str1 = strArray2[14];
              char[] chArray1 = new char[1]{ '~' };
              foreach (string str2 in str1.Split(chArray1))
              {
                char[] chArray2 = new char[1]{ '^' };
                string[] strArray3 = str2.Split(chArray2);
                try
                {
                  App.Variables.Add(strArray3[0], strArray3[1]);
                }
                catch
                {
                }
              }
              Security.End();
              return true;
            case "invalid_details":
              int num1 = (int) MessageBox.Show("Sorry, your username/password does not match!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
            case "time_expired":
              int num2 = (int) MessageBox.Show("Your subscription has expired!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
            case "hwid_updated":
              int num3 = (int) MessageBox.Show("New machine has been binded, re-open the application!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
            case "invalid_hwid":
              int num4 = (int) MessageBox.Show("This user is binded to another computer, please contact support!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
          Security.End();
          Process.GetCurrentProcess().Kill();
        }
        return false;
      }
    }

    public static bool Register(string username, string password, string email, string license)
    {
      if (!Constants.Initialized)
      {
        int num = (int) MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Security.End();
        Process.GetCurrentProcess().Kill();
      }
      if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(license)))
      {
        int num = (int) MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      string[] strArray1 = new string[0];
      using (WebClient webClient = new WebClient())
      {
        try
        {
          Security.Start();
          webClient.Proxy = (IWebProxy) null;
          string[] strArray2 = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection()
          {
            ["token"] = Encryption.EncryptService(Constants.Token),
            ["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
            ["aid"] = Encryption.APIService(OnProgramStart.AID),
            ["session_id"] = Constants.IV,
            ["api_id"] = Constants.APIENCRYPTSALT,
            ["api_key"] = Constants.APIENCRYPTKEY,
            ["session_key"] = Constants.Key,
            ["secret"] = Encryption.APIService(OnProgramStart.Secret),
            ["type"] = Encryption.APIService("register"),
            [nameof (username)] = Encryption.APIService(username),
            [nameof (password)] = Encryption.APIService(password),
            [nameof (email)] = Encryption.APIService(email),
            [nameof (license)] = Encryption.APIService(license),
            ["hwid"] = Encryption.APIService(Constants.HWID())
          }))).Split("|".ToCharArray());
          if (strArray2[0] != Constants.Token)
          {
            int num = (int) MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
            Security.End();
            Process.GetCurrentProcess().Kill();
          }
          if (Security.MaliciousCheck(strArray2[1]))
          {
            int num = (int) MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Process.GetCurrentProcess().Kill();
          }
          if (Constants.Breached)
          {
            int num = (int) MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Process.GetCurrentProcess().Kill();
          }
          switch (strArray2[2])
          {
            case "success":
              Security.End();
              return true;
            case "invalid_license":
              int num1 = (int) MessageBox.Show("License does not exist!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
            case "email_used":
              int num2 = (int) MessageBox.Show("Email has already been used!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
            case "invalid_username":
              int num3 = (int) MessageBox.Show("You entered an invalid/used username!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
          Process.GetCurrentProcess().Kill();
        }
        return false;
      }
    }

    public static bool ExtendSubscription(string username, string password, string license)
    {
      if (!Constants.Initialized)
      {
        int num = (int) MessageBox.Show("Please initialize your application first!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Security.End();
        Process.GetCurrentProcess().Kill();
      }
      if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(license))
      {
        int num = (int) MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      string[] strArray1 = new string[0];
      using (WebClient webClient = new WebClient())
      {
        try
        {
          Security.Start();
          webClient.Proxy = (IWebProxy) null;
          string[] strArray2 = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection()
          {
            ["token"] = Encryption.EncryptService(Constants.Token),
            ["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
            ["aid"] = Encryption.APIService(OnProgramStart.AID),
            ["session_id"] = Constants.IV,
            ["api_id"] = Constants.APIENCRYPTSALT,
            ["api_key"] = Constants.APIENCRYPTKEY,
            ["session_key"] = Constants.Key,
            ["secret"] = Encryption.APIService(OnProgramStart.Secret),
            ["type"] = Encryption.APIService("extend"),
            [nameof (username)] = Encryption.APIService(username),
            [nameof (password)] = Encryption.APIService(password),
            [nameof (license)] = Encryption.APIService(license)
          }))).Split("|".ToCharArray());
          if (strArray2[0] != Constants.Token)
          {
            int num = (int) MessageBox.Show("Security error has been triggered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
            Security.End();
            Process.GetCurrentProcess().Kill();
          }
          if (Security.MaliciousCheck(strArray2[1]))
          {
            int num = (int) MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Process.GetCurrentProcess().Kill();
          }
          if (Constants.Breached)
          {
            int num = (int) MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Process.GetCurrentProcess().Kill();
          }
          switch (strArray2[2])
          {
            case "success":
              Security.End();
              return true;
            case "invalid_token":
              int num1 = (int) MessageBox.Show("Token does not exist!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
            case "invalid_details":
              int num2 = (int) MessageBox.Show("Your user details are invalid!", ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
              Security.End();
              Process.GetCurrentProcess().Kill();
              return false;
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, ApplicationSettings.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
          Process.GetCurrentProcess().Kill();
        }
        return false;
      }
    }
  }
}
