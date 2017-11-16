using System.Collections.Generic;

public class Utilities
{
    //NOTE: After Unity2017.1, a header needs to be included in order to avoid the 406 error.
    public static Dictionary<string, string> GetWwwHeader()
    {
        var header = new Dictionary<string, string>();
        header.Add("Accept", "*/*");
        header.Add("Content-Type", "application/json");
        header.Add("User-Agent", "runscope/0.1");

        return header;
    }
}