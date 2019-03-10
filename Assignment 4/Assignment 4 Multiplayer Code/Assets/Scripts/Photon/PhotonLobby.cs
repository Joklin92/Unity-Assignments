using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonLobby : MonoBehaviourPunCallbacks {

    public static PhotonLobby instance;

    public GameObject battleButton;
    public GameObject cancelButton;

    void Awake() {
        instance = this;
    }



    void Start() {
        PhotonNetwork.ConnectUsingSettings(); //Connects to Master photon server.
    }
    


    void Update() {
        
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Player has connected to the Photon Master server");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log("Tried to join a random game but failed. There must be no open games available");
        CreateRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message) {
        Debug.Log("Tried to create a new room but failed, there must already be a room with the same name");
        CreateRoom();
    }

    void CreateRoom() {
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 10 };

        PhotonNetwork.CreateRoom("Room " + randomRoomName, roomOps);
    }

    public void OnBattleButtonClicked() {
        Debug.Log("Battle Button was clicked");
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnCancelButtonClicked() {
        Debug.Log("Cancel Button was clicked");
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

}
