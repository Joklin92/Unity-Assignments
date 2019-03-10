using UnityEngine;

public class Arrow : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;
    public Projectile arrow;

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
            if (target.GetComponent<EnemyController>().health <= 0)  {
                GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(effectInstance, 2f);
                EnemyDeath();
                PlayerController.instance.target = null;
            } else {
                target.GetComponent<EnemyController>().health -= arrow.damage;
                Debug.Log("Current Health: " + target.GetComponent<EnemyController>().health);
            }
            Destroy(gameObject);
        }
    

    void EnemyDeath() {
        Debug.Log(target.GetComponent<EnemyController>().enemy.name + " died you got: " + target.GetComponent<EnemyController>().enemy.currencyValue + " currency and: " + target.GetComponent<EnemyController>().enemy.scoreValue + " points!");
        UIController.instance.UpdateCurrencyText(target.GetComponent<EnemyController>().enemy.currencyValue);
        UIController.instance.UpdateScoreText(target.GetComponent<EnemyController>().enemy.scoreValue);
        Destroy(target.gameObject);
    }
}
