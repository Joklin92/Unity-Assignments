using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeTargeter : MonoBehaviour { 

    void OnMouseDown() {
        PlayerController.instance.DeTarget();
        PlayerController.instance.target = null;
    }

}
