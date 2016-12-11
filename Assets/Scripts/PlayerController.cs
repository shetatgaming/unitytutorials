using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpStrength = 5.0f;
    float direction;
    public bool grounded;
    Vector2 spawnPoint = Vector2.zero;
    public float respawnHeight = -5.0f;
    public GameObject eRCamera;
    public GameObject eRPlatformSpawner;

    void Start()
    {
        //Set the initial start position as the spawnPoint which will be used later for respawning.
        spawnPoint = transform.position;
    }

    void Update()
    {
        //direction gets set to a value between -1 and 1 and is used as a multiplyer for movement direction calculations.
        direction = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpStrength), ForceMode2D.Impulse);
        }

        //Check if the player is below a certain height threshhold and respawns if it is.
        if(transform.position.y < respawnHeight)
        {
            Respawn();
        }
    }

    /*
    Doing transform.Translate within FixedUpdate allows the smooth movement of a gameObject without having to Lerp between points.
    */
    void FixedUpdate()
    {
        transform.Translate(new Vector2(speed * direction * Time.deltaTime, 0.0f));
    }

    /*
    The respawn method resets the players position to the initial position from when the game started.
    Also, if there is a camera or platform spawner attached then it will reset them as well.
    */
    public void Respawn()
    {
        transform.position = spawnPoint;
        if (eRCamera != null)
            eRCamera.GetComponent<ERCameraController>().Respawn();
        if (eRPlatformSpawner != null)
            eRPlatformSpawner.GetComponent<PlatformSpawner>().ResetSpawner();
    }

    /*
    Using OnTriggerEnter2D and OnTriggerExit2D as a simple way to detect if the player is on the floor or not.
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            grounded = false;
        }
    }
}
