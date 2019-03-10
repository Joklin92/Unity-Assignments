using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

    [SerializeField] Text finalScore;

    void Start() {
        finalScore.text = "Total powerups collected: " + GameController.instance.puScore +
            "\n\n\nTotal time remaining: " + GameController.instance.timeRemaining +
            "\n\n\nTotal kills: " + GameController.instance.kills +
            "\n\n\nTotal Score: " + ((GameController.instance.puScore + GameController.instance.kills) * GameController.instance.timeRemaining);
    }
}
