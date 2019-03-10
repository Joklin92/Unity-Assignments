using UnityEngine;

public class PlayerController : MonoBehaviour {

    /*
    //Not hidden in Inspector for debugging purposes
    public int currency;
    public int score;
    public int health;
    */
    
    [HideInInspector] public int currency;
    [HideInInspector] public int score;
    [HideInInspector] public int health;

    public GameObject target = null;
    public int difficulty = 1;


    public static PlayerController instance;

    void Awake() {
        instance = this;
        DontDestroyOnLoad(this);

        health = 50;
        score = 0;
        currency = 100;
    }

    void Update() {
        TargetTower();
        if(Input.GetKeyDown(KeyCode.Escape)) {
            UIController.instance.ActivateMenuTab(); ;
        }
    }

    public void TargetTower() {
        if (Input.GetMouseButtonDown(0)) {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100000)) {

                if (hit.collider.tag == "Tower") {

                    Debug.Log("Hello from tower!");
                    UIController.instance.ActivateTowerTab();
                }
            }
        }
    }


    public void DeTarget()
    {
        UIController.instance.enemyInfoPanel.SetActive(false);
        UIController.instance.towerStatBuildPanel.SetActive(false);
        UIController.instance.towerTabPanel.SetActive(false);
        UIController.instance.ReturnToStandardTab();

    }



    public void Die() {
        UIController.instance.DisplayGameOverPanel();
        Time.timeScale = 0;
    }

    public void Win() {
        UIController.instance.DisplayWinScreen();
        Time.timeScale = 0;
    }
}
