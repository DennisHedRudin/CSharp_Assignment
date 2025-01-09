namespace MainApp.Helper;

public static class IdentifierGenerator
{
    public static string GenerateUniqueId() => Guid.NewGuid().ToString();
    
}
