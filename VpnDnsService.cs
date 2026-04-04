#if IOS
using NetworkExtension;
using Foundation;
#endif

namespace SpotifyPremium;

public static class VpnDnsService
{
    public static async Task ActivarDns()
    {
#if IOS
        var manager = NEDNSSettingsManager.SharedManager;
        await manager.LoadFromPreferencesAsync();
        var settings = new NEDNSSettings("xpe.nettt DNS") { Servers = new[] { "1.1.1.1", "1.0.0.1" }, MatchDomains = new[] { "*" } };
        manager.DNSSettings = settings;
        await manager.SaveToPreferencesAsync();
#endif
    }

    public static async Task DesactivarDns()
    {
#if IOS
        var manager = NEDNSSettingsManager.SharedManager;
        await manager.LoadFromPreferencesAsync();
        manager.DNSSettings = null;
        await manager.SaveToPreferencesAsync();
#endif
    }
}