using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    [SerializeField] public Text puScoreText;

    void Start() {
        instance = this;
        puScoreText.text = "Powerups Found: " + GameController.instance.puScore;
    }

    public void PUUpdater() {
        GetComponent<AudioSource>().Play();
        puScoreText.text = "Powerups Found: " + GameController.instance.puScore;
    }
}
