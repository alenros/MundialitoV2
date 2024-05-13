﻿
namespace Mundialito.Logic;

public class PrivateKeyValidator
{
    public static Boolean ValidatePrivateKey(String key, String email)
    {
        try
        {
            var guid = key.Substring(0, key.LastIndexOf("-"));
            var emailChecksum = int.Parse(key.Substring(key.LastIndexOf("-") + 1));
            Guid.Parse(guid);
            if (GetChecksum(email) == emailChecksum)
                return true;
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static String GeneratePrivateKey(String email)
    {
        return string.Format("{0}-{1}", Guid.NewGuid(), GetChecksum(email));
    }

    private static int GetChecksum(String email)
    {
        int sum = 0;
        foreach (char c in email)
        {
            sum += (int)c;
        }
        return sum;
    }
}
