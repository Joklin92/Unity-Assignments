using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonHandler : MonoBehaviour {

    public Text text;
    int rnd;
    public GameObject player;
    public GameObject spawnTarget;
    public GameObject amazingSpawnTarget;
    public GameObject[] walls;
    
    public int spawnAmount = 10;

    public void TextPrinter() {
        text.text = "You just pressed a button!";
        Debug.Log("You just pressed a button!");
    }

    public void Spawner() {
        Instantiate(spawnTarget);
        text.text = "Spawned Object!";
    }

    public void PlaySound() {
        GetComponent<AudioSource>().Play();
        text.text = "Boop";
    }

    public void Amazing() {
        for (int i = 0; i < spawnAmount; i++) {
            GameObject spawn = Instantiate(amazingSpawnTarget) as GameObject;
            spawn.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
        for (int i = 0; i < walls.Length; i++)
        {
            Instantiate(walls[i]);
        }

         rnd = (int)Random.Range(1, 6);
       // Debug.Log(rnd);
        if (rnd <= 2) {
            player.GetComponent<Renderer>().material.color = Color.red;
            text.text = "WOOW! You're RED :O";

        } else if (rnd <= 4) {
            player.GetComponent<Renderer>().material.color = Color.green;
            text.text = "WOOW! You're GREEN :O";

        } else {
            player.GetComponent<Renderer>().material.color = Color.black;
            text.text = "WOOW! You're BLACK :O";
        }
    }

    public void ExitGame() {
        Application.Quit();
    }

}
