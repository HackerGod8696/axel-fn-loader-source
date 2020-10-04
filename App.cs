// Decompiled with JetBrains decompiler
// Type: AuthGG.App
// Assembly: Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 21BEF00F-328C-44A0-AD30-584899C00B25
// Assembly location: C:\Users\sucht\Downloads\axelfn.exe

using System.Collections.Generic;

namespace AuthGG
{
  internal class App
  {
    public static string Error = (string) null;
    public static Dictionary<string, string> Variables = new Dictionary<string, string>();

    public static string GrabVariable(string name)
    {
      try
      {
        if (User.ID != null || User.HWID != null || (User.IP != null || !Constants.Breached))
          return App.Variables[name];
        Constants.Breached = true;
        return "User is not logged in, possible breach detected!";
      }
      catch
      {
        return "N/A";
      }
    }
  }
}
