using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Hollow172.Scoreboards;

public class PlayerDetector : MonoBehaviour
{
    //Function that response for interacting with different pickups or with finish line
    private void OnTriggerEnter(Collider other)
    {
        //Coin - destroy when picked up and add score
        if (other.gameObject.layer == 6)
        {
            FindObjectOfType<AudioManager>().Play("CoinPickup");
            Destroy(other.gameObject);
            ScoreUI.scoreAmount++;
        }
        //Super coin - turn on super jumps
        if (other.gameObject.layer == 8)
        {
            FindObjectOfType<AudioManager>().Play("SuperJump");
            Player.superJumps = true;
        }
        //Spiky ball - decrease health of player
        if (other.gameObject.layer == 9)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
            Player.health--;
        }
        //Finish line - load winning screen if player obtained 13 points
        if (other.gameObject.layer == 10 && ScoreUI.scoreAmount >= 13)
        {
            Timer.isWonFun();
            SceneManager.LoadScene("WinScene");
        }
        //Double jump - turn on double jumps
        if (other.gameObject.layer == 12)
        {
            FindObjectOfType<AudioManager>().Play("DoubleJump");
            Invoke("TurnOnDoubleJumps", 0.2f);
        }

    }

    //Turning on double jump
    void TurnOnDoubleJumps()
    {
        //Debug.Log("Double jumps turned on");
        Player.doubleJumps = true;
    }

}
