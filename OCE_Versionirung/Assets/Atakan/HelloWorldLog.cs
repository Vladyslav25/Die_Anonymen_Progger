using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorldLog : MonoBehaviour
{
    void Update()
    {
        AtakanHello();
    }

    public void AtakanHello()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("Hello from Atakan");
        }
    }
}
