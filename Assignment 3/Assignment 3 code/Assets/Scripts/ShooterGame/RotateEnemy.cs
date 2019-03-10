using UnityEngine;

public class RotateEnemy : MonoBehaviour {

    void Update() {
        transform.Rotate(new Vector3(0,2f, 0), Space.Self);
    }
}
