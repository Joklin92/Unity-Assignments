using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour {

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "AircraftJet") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads Car game
        } else if (col.gameObject.name == "Car") {
            GameController.instance.timeRemaining = TimerManager.instance.timeRemaining;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads Shooter game
        } else if (col.gameObject.name == "ThirdPersonController") {
            GameController.instance.kills = KillTracker.instance.kills;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads scoreboard
        }
    }   
}
