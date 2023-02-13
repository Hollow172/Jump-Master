using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCoin : MonoBehaviour
{
    [SerializeField] Transform teleportTarget; //Place to hide coin
    Vector3 coinPosition;

    //Hiding all types of coins except normal coin so they "respawn" after 5 seconds

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            coinPosition = gameObject.transform.position;
            gameObject.transform.position = teleportTarget.transform.position;
            yield return new WaitForSeconds(5);
            gameObject.transform.position = coinPosition;
        }

    }
}
