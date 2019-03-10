using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsolePrinter : MonoBehaviour { 
    
    void Start() {
        Debug.Log("Hello World");
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            Debug.Log("Respect");
        }
    }
}
