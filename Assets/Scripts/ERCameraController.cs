using UnityEngine;
using System.Collections;

public class ERCameraController : MonoBehaviour
{
    public float speed = 4.0f;

    /*
    Doing transform.Translate within FixedUpdate allows the smooth movement of a gameObject without having to Lerp between points.
    */
    void FixedUpdate()
    {
        transform.Translate(new Vector2(speed * Time.deltaTime, 0.0f));
    }

    /*
    Resets the camera to it's original position.
    */
    public void Respawn()
    {
        transform.position = new Vector3(0, 0, -10);
    }
}
