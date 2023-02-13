using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWorking : MonoBehaviour
{
 
    private Camera mainCamera;
    private GameObject player;

    float cameraDistOffset = 5; //offset of camera

    // Assinging variable mainCamera to camera that will follow the player
    // Assinging variable player to gameobject knightPlayer
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("knightPlayer");
    }

    // Each frame position of player is saved to the playerInfo then is written to the camera position so it follows the player
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x - 1.9f, playerInfo.y + 2.1f, playerInfo.z - cameraDistOffset);
    }
}