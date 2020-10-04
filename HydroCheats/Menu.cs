// Decompiled with JetBrains decompiler
// Type: HydroCheats.Menu
// Assembly: Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 21BEF00F-328C-44A0-AD30-584899C00B25
// Assembly location: C:\Users\sucht\Downloads\axelfn.exe

using System;
using System.Threading;

namespace HydroCheats
{
  internal class Menu
  {
    public static void Menus()
    {
      Console.Clear();
      Menu.PrintLogo();
      Console.WriteLine(" [1] Spoof");
      Console.WriteLine(" [2] Clean");
      Console.WriteLine(" [3] Cheat");
      Console.Write(" [>] Option : ");
      string str = Console.ReadLine();
      if (str == "1")
      {
        Console.Clear();
        Menu.PrintLogo();
        Menu.Menus();
        Console.WriteLine();
        Console.Write(" Spoofing.");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Spoofer.Woof();
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine();
        Console.Write(" Spoofed.");
        Thread.Sleep(2000);
        Console.Clear();
        Menu.Menus();
      }
      if (str == "2")
      {
        Console.Clear();
        Menu.PrintLogo();
        Menu.Menus();
        Console.WriteLine();
        Console.Write(" Cleaner.");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Write(".");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine();
        Console.Write(" Cleaned.");
        Thread.Sleep(2000);
        Console.Clear();
        Menu.Menus();
      }
      if (!(str == "3"))
        return;
      Console.Clear();
      Menu.PrintLogo();
      Console.WriteLine();
      Console.Write(" Injecting.");
      Thread.Sleep(1000);
      Console.Write(".");
      Thread.Sleep(1000);
      Console.Write(".");
      Spoofer.Injecter();
      Thread.Sleep(1000);
      Console.Clear();
      Console.WriteLine();
      Console.Write(" Injected.");
      Thread.Sleep(2000);
      Console.Clear();
      Menu.Menus();
    }

    public static void PrintLogo()
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("     █████████████████████████████████████████");
      Console.WriteLine("     ██▀▄─██▄─▀─▄█▄─▄▄─█▄─▄█████▄─▄▄─█▄─▀█▄─▄█");
      Console.WriteLine("     ██─▀─███▀─▀███─▄█▀██─██▀████─▄████─█▄▀─██");
      Console.WriteLine("     ▀▄▄▀▄▄▀▄▄█▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▀▀▄▄▄▀▀▀▄▄▄▀▀▄▄▀");
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}
