// Decompiled with JetBrains decompiler
// Type: AuthGG.Constants
// Assembly: Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 21BEF00F-328C-44A0-AD30-584899C00B25
// Assembly location: C:\Users\sucht\Downloads\axelfn.exe

using System;
using System.Linq;
using System.Security.Principal;

namespace AuthGG
{
  internal class Constants
  {
    public static bool Breached = false;
    public static bool Started = false;
    public static string IV = (string) null;
    public static string Key = (string) null;
    public static string ApiUrl = "https://api.auth.gg/csharp/";
    public static bool Initialized = false;
    public static Random random = new Random();

    public static string Token { get; set; }

    public static string Date { get; set; }

    public static string APIENCRYPTKEY { get; set; }

    public static string APIENCRYPTSALT { get; set; }

    public static string RandomString(int length) => new string(Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length).Select<string, char>((Func<string, char>) (s => s[Constants.random.Next(s.Length)])).ToArray<char>());

    public static string HWID() => WindowsIdentity.GetCurrent().User.Value;
  }
}
