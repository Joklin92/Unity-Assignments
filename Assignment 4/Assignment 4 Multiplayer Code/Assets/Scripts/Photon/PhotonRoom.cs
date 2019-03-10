using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PhotonView))]
public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks {

    public static PhotonRoom instance;
    private PhotonView pv;

   // public bool isGameLoaded;
    public int currentScene;
    public int multiplayerScene;
    public GameObject myAvatar;


    void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            if(instance != this) {
                Destroy(instance.gameObject);
                instance = this;
            }
        }
        DontDestroyOnLoad(gameObject);
        pv = GetComponent<PhotonView>();
    }



    public override void OnEnable() {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }


    public override void OnDisable() {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    public override void OnJoinedRoom() {
        base.OnJoinedRoom();
        Debug.Log("We are now in a room");
        if (!PhotonNetwork.IsMasterClient) return;
        StartGame();
    }

    private void StartGame() {
        PhotonNetwork.LoadLevel(multiplayerScene);
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) {
        currentScene = scene.buildIndex;
        if(currentScene == multiplayerScene) {
            {
                CreatePlayer();
            }
        }
    }

    private void CreatePlayer() {
        int spawnPicker = Random.Range(0, GameSetup.gs.spawnPoints.Length);
        myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), GameSetup.gs.spawnPoints[spawnPicker].position, 
            GameSetup.gs.spawnPoints[spawnPicker].rotation, 0);

        //   PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
    }
}
