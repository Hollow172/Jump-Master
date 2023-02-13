using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject RespawnPoint;
    [SerializeField] GameObject CheckpointDestroy; //Used to assign gameobject checkpoint
    [SerializeField] Transform teleportTarget; //New position of respawn
    [SerializeField] GameObject checkpointText;


    //After new position of respawn is set and text is shown it destroys checkpoint so it is not set twice (for example when player goes back)
    private IEnumerator OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("CheckpointSound");
        RespawnPoint.transform.position = teleportTarget.transform.position;
        checkpointText.SetActive(true);
        yield return new WaitForSeconds(5);
        Destroy(CheckpointDestroy);
    }

}
