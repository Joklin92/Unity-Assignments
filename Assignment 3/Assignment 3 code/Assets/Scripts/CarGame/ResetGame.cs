using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour { 

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
