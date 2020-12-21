using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CSharp8_7NullableType : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string sName = "12345";
        sName = null;
        Debug.Log(sName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
