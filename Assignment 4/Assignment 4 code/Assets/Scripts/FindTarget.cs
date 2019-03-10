using UnityEngine;

public class FindTarget : MonoBehaviour {

   public static Transform target;

    void Awake() {
        target = transform.GetChild(0);
    }
}
