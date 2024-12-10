using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int num = 10;
        string name = "Rozan Skaik";

        Debug.Log("My name: " + name);
        Debug.Log("The number is: " + num);
        Debug.Log("The sum = " + (num + num));
        Debug.Log("The minuc = " + (num - num));
        // Debug.Log("The multiply = " + (num * num));
        // Debug.Log("The division = " + (num / num));

        Debug.LogWarning("Oh Warning!");
        Debug.LogError("Oops Error!!");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
