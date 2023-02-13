using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    //By entering trampoline player jumps up
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            FindObjectOfType<AudioManager>().Play("Trampoline");
            Player.rigidbodyComponent.velocity = new Vector3(Player.horizontalInput * Player.runSpeedMultiplier, 10f, Player.rigidbodyComponent.velocity.z);
        }
    }
}
