using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadSign : MonoBehaviour
{
    [SerializeField] Text pressToRead;
    public GameObject SignMenu;
    bool isReading = false;

    //Turning off text "press E to read"
    void Start()
    {
        pressToRead.enabled = false;
    }
    //If player is nearby trigger ReadNearbySing() otherwise ExitNearbySing()
    private void Update()
    {
        if (pressToRead.enabled)
        {
            ReadNearbySign();
        }
        else
        {
            ExitNearbySign();
        }
    }
    //Enabling or Disabling text
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            pressToRead.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            pressToRead.enabled = false;
        }
    }
    //Activating and deactivating sign by pressing E
    void ReadNearbySign()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isReading = !isReading;
            SignMenu.SetActive(isReading);
        }
    }
    //Deactivating sign by leaving area
    void ExitNearbySign()
    {
        isReading = false;
        SignMenu.SetActive(false);
    }

}
