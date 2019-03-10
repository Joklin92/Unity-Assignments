using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
//using DG.Tweening;

public class movement : MonoBehaviour
{

    [SerializeField]
    private float speed = 5f;
    float delay = 2f;

    float posX;
    float posY;
    float posZ;

    float targetX = 10f;
    Timer t;

    Vector3 startPos;
    Vector3 endPos;
    [SerializeField]
    float lerpValue;

    void Start()
    {


        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        startPos = transform.position;
        endPos = new Vector3(10f, 1f, 1f);

        //    Invoke("CoroutineDemo", 1f);
        //  StartCoroutine("CoroutineDemo");
     //   MoveDoTween();
    }


    void Update()
    {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        // if (Timer())
        // MoveBasicTweening();

        //  MoveDoTween();

        FindGameObject();
    }



    void MoveLerp()
    {
        transform.position = Vector3.Lerp(startPos, endPos, lerpValue);
        transform.localScale = Vector3.Lerp(startPos, endPos, lerpValue);
        lerpValue += 0.01f;
    }

    bool Timer()
    {
        delay -= Time.deltaTime;
        if (delay <= 0) return true;

        return false;

    }

    void MoveDoTween() {
        
  //      transform.DOMoveX(10f,1f);
    }

    void MoveBasicTweening()
    {
        posX += (targetX - posX) * 0.01f;
        transform.position = new Vector3(posX, posY, posZ);
    }

    void MoveBasic()
    {
        if (transform.position.x <= 10)
            transform.position = new Vector3(transform.position.x + 0.01f * Time.deltaTime * speed, transform.position.y, transform.position.z);

    }

    void FindGameObject() {
        GameObject.Find("Sphere").GetComponent<Rigidbody>().useGravity = false;
    }

    IEnumerator CoroutineDemo()
    {
        Debug.Log("Sucker!!");
        yield return null;
        // yield return new WaitForSeconds(5f);
    }
}
