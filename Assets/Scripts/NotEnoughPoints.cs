using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEnoughPoints : MonoBehaviour
{
    [SerializeField] Text notEnoughPoints;

    void Start()
    {
        notEnoughPoints.enabled = false;
    }

    //If player does not have enough points and reaches finish line show up text that informs him so
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            if(ScoreUI.scoreAmount < 13)
            {
                notEnoughPoints.enabled = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            notEnoughPoints.enabled = false;
        }
    }
}
