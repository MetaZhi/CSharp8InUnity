using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public ref struct Test
{
    public void Dispose()
    {
        Debug.Log("Test Dispose");
    }
}

public class CSharp8_6DisposableRefSturct : MonoBehaviour
{
    void Start()
    {
        using var s = new Test();
    }
}
