using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PowerUp : MonoBehaviour {

    float posX;
    float posY;

    float targetMaxPos = -50f;
    float targetMinPos = 500f;

    private bool hasCollided = false;

    void Awake() {
        posX = transform.position.x;
        posY = transform.position.y;        
    }

    IEnumerator Start() {
        while(true) {
            yield return StartCoroutine(PUMover(transform, transform.position, new Vector3(posX, posY, targetMaxPos), Random.Range(2.0f, 5.5f)));
            yield return StartCoroutine(PUMover(transform, transform.position, new Vector3(posX,posY,targetMinPos), Random.Range(2.0f, 5.5f)));
        }
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "AircraftJet" && !hasCollided) {
            hasCollided = true;
            GameController.instance.puScore++;            
            ScoreManager.instance.PUUpdater();
            Destroy(gameObject);
            StartCoroutine(colorSwitch(ScoreManager.instance.puScoreText));
        }
    }

    void LateUpdate() {
        hasCollided = false;
    }

    IEnumerator colorSwitch(Text text) {
        text.rectTransform.DOShakeAnchorPos(2f, 50f, 10, 90f, false, false);
        text.DOColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)), 0.2f);
        yield return null;
    }

    IEnumerator PUMover(Transform t, Vector3 startPos, Vector3 endPos, float time) {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i<1.0f) {
            i += Time.deltaTime * rate;
            t.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        yield return new WaitForSeconds(Random.Range(0.2f, 2f));
    }
}






