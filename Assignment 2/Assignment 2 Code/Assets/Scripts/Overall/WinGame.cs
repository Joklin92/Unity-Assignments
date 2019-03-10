using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {

    GameObject derp;

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Car" || col.gameObject.name == "AircraftJet") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else if(col.gameObject.name == "ThirdPersonController") {
            SceneManager.LoadScene(0);
        }
    }   

}
