using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AltTower : MonoBehaviour {

    public GameObject projectilePrefab;

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Enemy") {
         //   GameObject g = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
          //  g.GetComponent<Arrow>().target = col.transform;
        }
    }

}
