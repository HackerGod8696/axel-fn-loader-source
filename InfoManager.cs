// Decompiled with JetBrains decompiler
// Type: AuthGG.InfoManager
// Assembly: Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 21BEF00F-328C-44A0-AD30-584899C00B25
// Assembly location: C:\Users\sucht\Downloads\axelfn.exe

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace AuthGG
{
  internal class InfoManager
  {
    private Timer timer;
    private string lastGateway;

    public InfoManager() => this.lastGateway = this.GetGatewayMAC();

    public void StartListener() => this.timer = new Timer((TimerCallback) (_ => this.OnCallBack()), (object) null, 5000, -1);

    private void OnCallBack()
    {
      this.timer.Dispose();
      if (!(this.GetGatewayMAC() == this.lastGateway))
      {
        Constants.Breached = true;
        int num = (int) MessageBox.Show("ARP Cache poisoning has been detected!", OnProgramStart.Name, MessageBoxButton.OK, MessageBoxImage.Hand);
        Process.GetCurrentProcess().Kill();
      }
      else
        this.lastGateway = this.GetGatewayMAC();
      this.timer = new Timer((TimerCallback) (_ => this.OnCallBack()), (object) null, 5000, -1);
    }

    public static IPAddress GetDefaultGateway() => ((IEnumerable<NetworkInterface>) NetworkInterface.GetAllNetworkInterfaces()).Where<NetworkInterface>((Func<NetworkInterface, bool>) (n => n.OperationalStatus == OperationalStatus.Up)).Where<NetworkInterface>((Func<NetworkInterface, bool>) (n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)).SelectMany<NetworkInterface, GatewayIPAddressInformation>((Func<NetworkInterface, IEnumerable<GatewayIPAddressInformation>>) (n =>
    {
      IPInterfaceProperties ipProperties = n.GetIPProperties();
      return ipProperties == null ? (IEnumerable<GatewayIPAddressInformation>) null : (IEnumerable<GatewayIPAddressInformation>) ipProperties.GatewayAddresses;
    })).Select<GatewayIPAddressInformation, IPAddress>((Func<GatewayIPAddressInformation, IPAddress>) (g => g?.Address)).Where<IPAddress>((Func<IPAddress, bool>) (a => a != null)).FirstOrDefault<IPAddress>();

    private string GetArpTable()
    {
      string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
      using (Process process = Process.Start(new ProcessStartInfo()
      {
        FileName = pathRoot + "Windows\\System32\\arp.exe",
        Arguments = "-a",
        UseShellExecute = false,
        RedirectStandardOutput = true
      }))
      {
        using (StreamReader standardOutput = process.StandardOutput)
          return standardOutput.ReadToEnd();
      }
    }

    private string GetGatewayMAC() => new Regex(string.Format("({0} [\\W]*) ([a-z0-9-]*)", (object) InfoManager.GetDefaultGateway().ToString())).Match(this.GetArpTable()).Groups[2].ToString();
  }
}
