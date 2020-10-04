// Decompiled with JetBrains decompiler
// Type: AuthGG.Program
// Assembly: Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 21BEF00F-328C-44A0-AD30-584899C00B25
// Assembly location: C:\Users\sucht\Downloads\axelfn.exe

using HydroCheats;
using System;
using System.Diagnostics;
using System.Windows;

namespace AuthGG
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      OnProgramStart.Initialize("skullware", "45067", "y9GAUEb89kuEHt4iKHsVbDzYQSxwCun0kLA", "1.0");
      if (ApplicationSettings.Freemode)
      {
        int num1 = (int) MessageBox.Show("Freemode is active, bypassing login!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
      }
      if (!ApplicationSettings.Status)
      {
        int num2 = (int) MessageBox.Show("Application is disabled!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      Program.PrintLogo();
      Console.Title = "AxelFN | trashv2#4617";
      Console.WriteLine(" [1] Register");
      Console.WriteLine(" [2] Login");
      Console.Write(" [>] Option : ");
      string str1 = Console.ReadLine();
      if (str1 == "1")
      {
        if (!ApplicationSettings.Register)
        {
          int num2 = (int) MessageBox.Show("Register is not enabled, please try again later!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
          Process.GetCurrentProcess().Kill();
        }
        else
        {
          Console.Clear();
          Program.PrintLogo();
          Console.WriteLine();
          Console.Write(" Username : ");
          string username = Console.ReadLine();
          Console.Write(" Password : ");
          string str2 = Console.ReadLine();
          Console.Write(" Email : ");
          string str3 = Console.ReadLine();
          Console.Write(" License : ");
          string str4 = Console.ReadLine();
          string password = str2;
          string email = str3;
          string license = str4;
          if (API.Register(username, password, email, license))
          {
            int num2 = (int) MessageBox.Show("You have successfully registered!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
            Menu.Menus();
          }
        }
      }
      else if (str1 == "2")
      {
        if (!ApplicationSettings.Login)
        {
          int num2 = (int) MessageBox.Show("Login is not enabled, please try again later!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
          Process.GetCurrentProcess().Kill();
        }
        else
        {
          Console.Clear();
          Program.PrintLogo();
          Console.WriteLine();
          Console.Write(" Username : ");
          string username = Console.ReadLine();
          Console.Write(" Password : ");
          string password = Console.ReadLine();
          if (API.Login(username, password))
          {
            int num2 = (int) MessageBox.Show("You have successfully logged in!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
            Console.Clear();
            Program.PrintLogo();
            Console.ForegroundColor = ConsoleColor.White;
            API.Log(username, "Logged in!");
            Menu.Menus();
          }
        }
      }
      else if (str1 == "4")
      {
        Console.Clear();
        Program.PrintLogo();
        Console.WriteLine();
        Console.Write(" Username : ");
        string username = Console.ReadLine();
        Console.Write(" Password : ");
        string str2 = Console.ReadLine();
        Console.Write(" Key : ");
        string str3 = Console.ReadLine();
        string password = str2;
        string license = str3;
        if (API.ExtendSubscription(username, password, license))
        {
          int num2 = (int) MessageBox.Show("You have successfully extended your subscription!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
      }
      else if (str1 == "3")
      {
        Console.Clear();
        Program.PrintLogo();
        Console.WriteLine();
        Console.Write(" Key : ");
        if (API.AIO(Console.ReadLine()))
        {
          int num2 = (int) MessageBox.Show("Welcome back to my application!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Asterisk);
          Process.GetCurrentProcess().Kill();
        }
        else
        {
          int num2 = (int) MessageBox.Show("Your key does not exist!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
          Process.GetCurrentProcess().Kill();
        }
      }
      Console.Read();
    }

    public static void PrintLogo()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine();
      Console.WriteLine("     █████████████████████████████████████████");
      Console.WriteLine("     ██▀▄─██▄─▀─▄█▄─▄▄─█▄─▄█████▄─▄▄─█▄─▀█▄─▄█");
      Console.WriteLine("     ██─▀─███▀─▀███─▄█▀██─██▀████─▄████─█▄▀─██");
      Console.WriteLine("     ▀▄▄▀▄▄▀▄▄█▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▀▀▄▄▄▀▀▀▄▄▄▀▀▄▄▀");
      Console.WriteLine();
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}
