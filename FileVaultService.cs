using System.Security.Cryptography;
using System.Text;

namespace SpotifyPremium;

public static class FileVaultService
{
    private static readonly string Key = "xpe.nettt-secret-32bytes-key!!"; // cámbiala por tu propia clave larga
    private static string VaultPath => Path.Combine(FileSystem.AppDataDirectory, "Vault");

    public static void Init() => Directory.CreateDirectory(VaultPath);

    public static async Task<string> GuardarArchivo(Stream stream, string nombreOriginal)
    {
        Init();
        var ruta = Path.Combine(VaultPath, Guid.NewGuid() + ".vault");

        using var aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(Key);
        aes.IV = new byte[16];

        using var fs = new FileStream(ruta, FileMode.Create);
        using var crypto = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write);
        await stream.CopyToAsync(crypto);

        return nombreOriginal;
    }

    public static List<string> ObtenerArchivos()
    {
        Init();
        return Directory.GetFiles(VaultPath, "*.vault").Select(f => Path.GetFileNameWithoutExtension(f)).ToList();
    }

    public static void EliminarArchivo(string nombre)
    {
        var ruta = Path.Combine(VaultPath, nombre + ".vault");
        if (File.Exists(ruta)) File.Delete(ruta);
    }
}