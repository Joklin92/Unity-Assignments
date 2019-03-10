using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickere : MonoBehaviour
{

    Light testLight;
    public float minWaitTime = 0.3f;
    public float maxWaitTime = 2.0f;

    void Start()
    {
        testLight = GetComponent<Light>();
        StartCoroutine(Flickering());
    }

    IEnumerator Flickering() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            testLight.enabled = !testLight.enabled;
        }
    }
}
