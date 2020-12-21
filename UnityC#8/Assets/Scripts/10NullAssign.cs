using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharp8_10NullAssign : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> numbers = null;
        int? i = null;

        numbers ??= new List<int>();
        numbers.Add(i ??= 17);
        numbers.Add(i ??= 20);

        Debug.Log(string.Join(" ", numbers));  // output: 17 17
        Debug.Log(i);  // output: 17

        var s1 = $@"123";
        var s2 = @$"123";
    }
    
    
}
