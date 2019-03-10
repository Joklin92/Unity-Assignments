
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private GameObject explosion;
    private float despawnTimer = 1f;

    void OnCollisionEnter(Collision col) { 
            if (col.gameObject.tag == "Enemy") {
            Destroy(col.gameObject);
            GameObject ex = Instantiate(explosion, transform.position, transform.rotation);
            ex.GetComponent<AudioSource>().Play();
            Destroy(ex, despawnTimer);
        }
    }
}
