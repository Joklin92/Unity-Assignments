using UnityEngine;
using System.Collections;

public class GunShot : MonoBehaviour
{

    public GameObject projectile;
    private float despawnTimer = 3f;

    public float speed = 20;

    void Update() {

        if (Input.GetButtonDown("Fire1")) {
            Rigidbody instantiatedProjectile = Instantiate(projectile.GetComponent<Rigidbody>(),
                transform.position,
                transform.rotation) as Rigidbody;

            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            Destroy(instantiatedProjectile.gameObject, despawnTimer);


        }
    }
}
