using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImenuActive : MonoBehaviour
{
    public static GameObject UImenu;

    private void Start()
    {
        UImenu = gameObject;
    }

    public static void SetActiveMenu()
    {
        UImenu.SetActive(true);
    }
}
