using UnityEngine;
using System.Collections;

public class ERSpikes : MonoBehaviour
{
    /*
    Checks if the player has collided with this object and respawns the player and camera if it hit.
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GetComponentInParent<ERCameraController>().Respawn();
            col.GetComponent<PlayerController>().Respawn();
        }
    }
}
