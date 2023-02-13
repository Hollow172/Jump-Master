using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    int zoom = 80;
    int normal = 60;
    float smooth = 5;

    private bool isZoomed = false;


    // Code that allows player to zoom out camera by pressing tab (increase of cameras pov)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isZoomed = !isZoomed;
        }

        if (isZoomed)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
        }
    }


}
