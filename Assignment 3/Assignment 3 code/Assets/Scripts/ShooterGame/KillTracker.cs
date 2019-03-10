using UnityEngine;
using UnityEngine.UI;

public class KillTracker : MonoBehaviour {

    public static KillTracker instance;
    [SerializeField] Text killText;
    public int kills = 0;

    void Start() {
        instance = this;
        killText.text = "Enemies Killed: " + kills;
    }

    public void UpdateScore() {
        kills++;
        killText.text = "Enemies Killed: " + kills;
    }
}
