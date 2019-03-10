using UnityEngine;

public class TimeCapsules : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.name == "Car") {
            TimerManager.instance.AddTime();
            gameObject.SetActive(false);
        }
    }
}
