using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour {

    float posZ;
    float posY;

    float targetMaxPos = 4.25f;
    float targetMinPos = 0f;

    void Awake() {
        posZ = transform.position.z;
        posY = transform.position.y;
    }

    IEnumerator Start() {
        while (true) {
            yield return StartCoroutine(TargetMove(transform, transform.position, new Vector3(posZ, posY, targetMaxPos), Random.Range(2.0f, 5.5f)));
            yield return StartCoroutine(TargetMove(transform, transform.position, new Vector3(posZ, posY, targetMinPos), Random.Range(2.0f, 5.5f)));
        }
    }

    IEnumerator TargetMove(Transform t, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            t.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        yield return new WaitForSeconds(Random.Range(0.2f, 2f));
    }


}
