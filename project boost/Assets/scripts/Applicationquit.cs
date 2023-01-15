using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Applicationquit : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("quit");
            Application.Quit();
        }
    }
}
