using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Text scoreText;
    public static int puScore;

    void Awake() {
        scoreText = GetComponent<Text>();
        puScore = 0;
    }

    void Update() {
        scoreText.text = "Powerups Found: " + puScore;
    }
}
