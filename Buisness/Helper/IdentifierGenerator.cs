
using System.Diagnostics;

namespace MainApp.Helper;

public static class IdentifierGenerator
{
    public static string GenerateUniqueID()
    {
		try
		{
            return Guid.NewGuid().ToString();
			
        }
		catch (Exception ex)
		{

			Debug.WriteLine(ex.Message);
			return null!;
		}
    }
}
