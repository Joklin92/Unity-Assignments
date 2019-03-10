using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Aeroplane;

namespace myStuff { 
public class PowerUp : MonoBehaviour {

        private bool hasCollided = false;
        
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "AircraftJet" && !hasCollided) {
                hasCollided = true;
                col.gameObject.GetComponent<AudioSource>().Play(); 
                Destroy(gameObject);
                Score.puScore++;
        }
    }
        void LateUpdate() {
            hasCollided = false;
        }
}
}





