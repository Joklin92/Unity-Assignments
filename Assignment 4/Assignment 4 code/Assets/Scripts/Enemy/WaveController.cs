using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public static WaveController instance;
    public enum SpawnState { SPAWNING, WAITING};
    private SpawnState state = SpawnState.WAITING;


    [SerializeField] private float timeToNextWave = 30f;
    private int nextWave = 0;

    public List<Transform> spawnPoints = new List<Transform>();
    private List<Transform> usedSpawnPoints = new List<Transform>();

    public Wave[] waves;

    #region Setup
    [System.Serializable]
    public class Wave {
        public string waveName;
        public Transform[] enemies;
    }

    void Awake() {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    void Start() {
        if (spawnPoints.Count == 0) {
            Debug.LogError("No spawn points defined");
        }
    }
    #endregion

    void Update() {
        if(nextWave < waves.Length) {
            if (timeToNextWave > 0) {               
            timeToNextWave -= Time.deltaTime;
            UIController.instance.waveTimerText.text = "Next wave begins in: " + timeToNextWave;
            }
            if (timeToNextWave <= 0)   {
            timeToNextWave = 0;
            UIController.instance.waveTimerText.text = "Wave begun!";
                  if (state != SpawnState.SPAWNING) {
                  StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
        } else if(nextWave >= waves.Length && FindObjectsOfType<Enemy>() == null) {
            UIController.instance.waveTimerText.text = "Waves defeated!";
            Debug.Log("Hooray you did it!");
            PlayerController.instance.Win();
        }
    }

    #region Spawning
    IEnumerator SpawnWave(Wave wave) {
        Debug.Log("Spawning wave: " + wave.waveName);
        nextWave++;
        UIController.instance.waveCounterText.text = "Wave: " + nextWave;
        state = SpawnState.SPAWNING;
        if(PlayerController.instance.difficulty == 1) { 
        for (int i = 0; i < wave.enemies.Length; i++) {
            SpawnEnemy(wave.enemies[i]);
        }
        } else if(PlayerController.instance.difficulty == 2) {
            for (int i = 0; i < wave.enemies.Length; i++) {
                SpawnEnemy(wave.enemies[i]);
                SpawnEnemy(wave.enemies[i]);
            }
        } else if (PlayerController.instance.difficulty == 3) {
            for (int i = 0; i < wave.enemies.Length; i++)
            {
                SpawnEnemy(wave.enemies[i]);
                SpawnEnemy(wave.enemies[i]);
                SpawnEnemy(wave.enemies[i]);
            }
        }

        yield return new WaitForSeconds(5f);
        if(PlayerController.instance.difficulty == 1) {
            timeToNextWave = 30f;
        } else if(PlayerController.instance.difficulty == 2) {
            timeToNextWave = 20f;
        } else if(PlayerController.instance.difficulty == 3) { 
        timeToNextWave = 10f;
        }

        state = SpawnState.WAITING;

        for (int i = 0; i < usedSpawnPoints.Count; i++) {
            spawnPoints.Add(usedSpawnPoints[i]);
        }
        yield break;
    }

    void SpawnEnemy(Transform enemy) {
        int spToPick = Random.Range(0, spawnPoints.Count-1);
        Transform sp = spawnPoints[spToPick];
        Instantiate(enemy, sp.position, sp.rotation);
        usedSpawnPoints.Add(sp);
        spawnPoints.RemoveAt(spToPick);
        Debug.Log("Spawning enemy: " + enemy.name);
    }
    #endregion
}