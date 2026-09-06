using AdysTech.CredentialManager;
using System;
using System.Net;
using TerraFX.Interop.Windows;

namespace SS14.Launcher.Models.Data;

public sealed class CredentialStorage
{
    private const string TargetPrefix = "SS14.Launcher:";

    private static string GetTarget(Guid userId)
    {
        return $"{TargetPrefix}{userId:D}";
    }

    public void Store(Guid userId, string token)
    {
        CredentialManager.SaveCredentials(
            GetTarget(userId),
            new NetworkCredential("SS14", token),
            persistence: Persistence.LocalMachine);
    }

    public string? Get(Guid userId)
    {
        return CredentialManager
            .GetCredentials(GetTarget(userId))
            ?.Password;
    }

    public void Remove(Guid userId)
    {
        CredentialManager.RemoveCredentials(GetTarget(userId));
    }
}
