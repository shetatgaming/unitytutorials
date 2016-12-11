using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour
{
    /*
    Checks to see if the player has come into contact with the goal object and if so creates a debug message.
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("You won the game!");
        }
    }
}
