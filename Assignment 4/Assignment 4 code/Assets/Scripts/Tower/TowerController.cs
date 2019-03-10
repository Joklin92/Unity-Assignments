using UnityEngine;

public class TowerController : MonoBehaviour {
    
    public Tower tower1;
    public Tower tower2;
    public Tower tower3;
    public Tower currentTower;

    [Header("Attributes")]
    private float fireRate;
    private float fireCountDown = 0f;
    public float range;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    [SerializeField] private Transform partToRotate;
    public float turnSpeed = 10f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private Transform target; 

    void Start() {
        currentTower = tower1;
        fireRate = currentTower.fireRate;
        range = currentTower.range;
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }


    void UpdateTarget() {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
        } else {
            target = null;
        }
    }

    void Update() {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountDown < Time.time) {
            Shoot();
            fireCountDown = Time.time + fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    void Shoot() {
        GameObject projectileGO =  Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        if (projectilePrefab.name == "Arrow") {
            Arrow arrow = projectileGO.GetComponent<Arrow>();
            if (arrow != null) arrow.Seek(target);
        } else if(projectilePrefab.name == "FireBall") {
            FireBall fireball = projectileGO.GetComponent<FireBall>();
            if(fireball != null) fireball.Seek(target);            
        } else if(projectilePrefab.name == "FrostBolt") {
            FrostBolt frostBolt = projectileGO.GetComponent<FrostBolt>();
            if (frostBolt != null) frostBolt.Seek(target);
        } else if(projectilePrefab.name == "Lase") {
            Laser laser = projectileGO.GetComponent<Laser>();
            //WIP
        }
    }

    void OnMouseDown() {
        UIController.instance.DisplayTowerInfo(currentTower);
        PlayerController.instance.target = gameObject;
    }

    public void UpgradeTower() {
        if (currentTower == tower2 && PlayerController.instance.currency >= tower3.price) {
            currentTower = tower3;
            UIController.instance.DisplayTowerInfo(tower3);
            UIController.instance.UpdateCurrencyText(-tower3.price);
        Debug.Log("Tower Upgraded");
        }
        else if (currentTower == tower1 && PlayerController.instance.currency >= tower2.price) {
            currentTower = tower2;
            UIController.instance.DisplayTowerInfo(tower2);
            UIController.instance.UpdateCurrencyText(-tower2.price);
        Debug.Log("Tower Upgraded");
        } else {
            Debug.LogError("Tower could not be upgraded!");
        }
    }
}
