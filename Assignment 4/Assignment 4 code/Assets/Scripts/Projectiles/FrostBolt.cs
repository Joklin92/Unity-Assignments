using UnityEngine;
using System.Collections;
using Pathfinding;

public class FrostBolt : MonoBehaviour {

    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    public Projectile frostBolt;


    public void Seek(Transform _target) {
        target = _target;
    }

    void Update() {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget() {
        Debug.Log("FrostBolt Here");
        if (target.GetComponent<EnemyController>().currentSpeed == target.GetComponent<EnemyController>().GetComponent<AIPath>().maxSpeed) { 
            target.GetComponent<EnemyController>().GetComponent<AIPath>().maxSpeed *= .8f;
        }
             
        if (target.GetComponent<EnemyController>().health <= 0) {
            GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectInstance, 2f);
            EnemyDeath();
            PlayerController.instance.target = null;
        } else {
            target.GetComponent<EnemyController>().health -= frostBolt.damage;
            Debug.Log("Current Health: " + target.GetComponent<EnemyController>().health);
        }
        Destroy(gameObject);
    }

    void EnemyDeath()
    {
        Debug.Log(target.GetComponent<EnemyController>().enemy.name + " died you got: " + target.GetComponent<EnemyController>().enemy.currencyValue + " currency and: " + target.GetComponent<EnemyController>().enemy.scoreValue + " points!");
        UIController.instance.UpdateCurrencyText(target.GetComponent<EnemyController>().enemy.currencyValue);
        UIController.instance.UpdateScoreText(target.GetComponent<EnemyController>().enemy.scoreValue);
        Destroy(target.gameObject);
    }
}

