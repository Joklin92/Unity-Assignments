using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

   public float timeRemaining = 30f;
    [SerializeField] Text timerText;
    [SerializeField] Text warningText;

    public static TimerManager instance;

    void Start() {
        instance = this;
        warningText.text = "";
        timerText.text = "" + timeRemaining;
        Time.timeScale = 1;
    }
    
    void Update() {
        if (timeRemaining > 3) {
            warningText.text = "";
            timeRemaining -= Time.deltaTime;
            timerText.text = "" + timeRemaining;
        } else if(timeRemaining <= 3) {
            timeRemaining -= Time.deltaTime;
            timerText.text = "";
            warningText.text = "" + timeRemaining;
            warningText.color = Color.red;
        }
        if (timeRemaining <= 0.0f) {
            StartCoroutine("LoseGame");
        }
    }

    public void AddTime() {
       timeRemaining += 12.5f;
    }

    IEnumerator LoseGame() {
        warningText.text = "Game Over";
        Time.timeScale = 0;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
