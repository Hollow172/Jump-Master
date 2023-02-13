using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationFall : MonoBehaviour
{
    [SerializeField] Transform teleportTarget; //respawn
    [SerializeField] GameObject player; 

    //If player falls to water this script makes him teleport to respawn point
    //Also it sets his vertical speed to 0, decreases his health and turns off super jump and double jump
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            FindObjectOfType<AudioManager>().Play("WaterSplash");
            player.transform.position = teleportTarget.transform.position;
            Player.rigidbodyComponent.velocity = new Vector3(Player.horizontalInput * Player.runSpeedMultiplier, 0, Player.rigidbodyComponent.velocity.z);
            Player.superJumps = false;
            Player.doubleJumps = false;
            Player.health--;
        }
    }
}
