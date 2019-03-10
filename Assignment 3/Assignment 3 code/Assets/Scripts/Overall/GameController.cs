using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;

    [HideInInspector] public int puScore = 0;
    [HideInInspector] public int kills = 0;
    [HideInInspector] public float timeRemaining = 30f;

    void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
