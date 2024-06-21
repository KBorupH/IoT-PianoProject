using PianoUI.Models.Networks;
using SimpleWifi;

namespace PianoNetworker.Networking;

public class WiFi : INetworking
{
    private string netSSID = "Linksys11550";
    private string netPass = "Kode1234";

    public void Setup()
    {
        Wifi wifi = new Wifi();
        AccessPoint? ac = wifi.GetAccessPoints().FirstOrDefault(ap => ap.Name.Equals(netSSID));

        if (ac != null)
        {
            AuthRequest authRequest = new AuthRequest(ac);
            authRequest.Password = netPass;
            ac.Connect(authRequest);
        }
    }
}
