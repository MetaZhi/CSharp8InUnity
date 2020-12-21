using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharp8_5StaticLocal : MonoBehaviour
{
    int M()
    {
        int y = 5;
        int x = 7;
        return Add(x, y);

        static int Add(int left, int right) => left + right;
    }

    readonly ref struct Hello
    {
        
    }
}
