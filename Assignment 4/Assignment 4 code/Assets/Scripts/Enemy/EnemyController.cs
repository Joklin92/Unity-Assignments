using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour {

    private bool isAlive;
    public Enemy enemy;
    public int health;
    public float currentSpeed;

    public GameObject target;

    void Awake() {
        target = GameObject.Find("PlayerBase");
        health = enemy.health;
        currentSpeed = GetComponent<AIPath>().maxSpeed;
    }
    void Start() {
    }

    void OnTriggerEnter(Collider col) {
        if (col.name == "PBCollider") {
            if(gameObject.name == "Goblin(Clone)") { 
            PlayerController.instance.health--;
            } else if(gameObject.name == "Demonic Wizard(Clone)") {
                PlayerController.instance.health -= 2;
            } else if(gameObject.name == "Reaper(Clone)") {
            PlayerController.instance.health -= 5;
            } else {
                PlayerController.instance.health -= 10;
            }
            UIController.instance.healthText.text = PlayerController.instance.health.ToString();
            if (PlayerController.instance.health <= 0) PlayerController.instance.Die();
            Destroy(gameObject);           
        }
    }

    void OnMouseDown() {
        UIController.instance.DisplayEnemyInfo(this);
        UIController.instance.ReturnToStandardTab();
        PlayerController.instance.target = gameObject;
    }

    public void Die() {
        UIController.instance.UpdateCurrencyText(5);
        UIController.instance.UpdateScoreText(100);
        Destroy(gameObject);
    }
}