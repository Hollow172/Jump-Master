using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretSign : MonoBehaviour
{
    public GameObject SignMenu; //menu of a sign
    public GameObject alreadyRested; //text that says that the player already rested
    public GameObject sleepImg; //"sleeping" screen
    public static bool isSleeping = false;
    bool isReading = false;
    bool isInTheArea = false;
    bool didRest = false;

    //If player is in the range of a sign then it triggers ReadNearbySing function and if he is reading then Rest function is triggered
    private void Update()
    {
        if (isInTheArea)
        {
            ReadNearbySign();
            if (isReading)
            {
                Rest();
            }
        }
        else
        {
            ExitNearbySign();
        }
    }
    //Checking if player is in the range of sign
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            isInTheArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            isInTheArea = false;
        }
    }
    //Activating and deactivating sign text when pressing E
    void ReadNearbySign()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isReading = !isReading;
            SignMenu.SetActive(isReading);
            if(isReading == false) //turns of already rested text when player stops reading sign
            {
                alreadyRested.SetActive(false);
            }
        }
    }
    //Deactivating sign text when moving away
    void ExitNearbySign()
    {
        isReading = false;
        SignMenu.SetActive(false);
        alreadyRested.SetActive(false);
    }
    //Resting function - if player did not rest before it adds him health but it adds time penalty
    //If player already rested then it activates text that says so
    void Rest()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!didRest)
            {
                sleepImg.SetActive(true);
                Player.health++;
                Invoke("setRestPenalty", 1f);
                Player.rigidbodyComponent.isKinematic = true;
                isSleeping = true;
                Invoke("Sleeping", 2.5f);
                didRest = true;
            }
            else
            {
                alreadyRested.SetActive(true);
            }

        }
    }
    //Functions for Invoke
    //Turning on rest penalty
    void setRestPenalty()
    {
        Timer.restPenalty();
    }
    //Waking up from rest
    void Sleeping()
    {
        sleepImg.SetActive(false);
        Player.rigidbodyComponent.isKinematic = false;
        isSleeping = false;
    }

}
