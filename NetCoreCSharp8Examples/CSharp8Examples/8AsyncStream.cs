using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CSharp8_8AsyncStream
{
    
    public static async System.Collections.Generic.IAsyncEnumerable<int> GenerateSequence()
    {
        for (int i = 0; i < 20; i++)
        {
            await Task.Delay(100);
            yield return i;
        }
    }
}
