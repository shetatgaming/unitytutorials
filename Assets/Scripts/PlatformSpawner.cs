using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour
{
    bool canSpawn = true;
    public GameObject platformPrefab;
    public GameObject firstPlatform;
    public GameObject previousPlatform;
    public float maxHeight = 2.5f;
    public float minHeight = -4.5f;
    public float spawnDelay = 2.0f;


    // Use this for initialization
    void Start()
    {
        previousPlatform = firstPlatform;
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpawn)
        {
            canSpawn = false;
            StartCoroutine(SpawnPlatform());
        }
    }

    /*
    1/ Generates a random spawn position between the min and max height.
    2/ Checks if the spawn height is reachable and makes it so if not.
    3/ Spawns the new platform at the position generated.
    4/ Sets the new platform to the previous platform var to use for height checking on the next platform.
    5/ Sets up a time delayed Destroy to avoid build up of useless platforms.
    6/ Pauses the coroutine for a set time.
    7/ Unpauses and sets canSpawn to true to allow the next platform to be spawned.
    */
    IEnumerator SpawnPlatform()
    {
        Vector2 spawnPos = new Vector2(transform.position.x, Random.Range(minHeight, maxHeight));
        if(spawnPos.y - previousPlatform.transform.position.y > 2.5f)
        {
            spawnPos.y = previousPlatform.transform.position.y + 2.5f;
        }
        GameObject newPlatform = Instantiate(platformPrefab, spawnPos, Quaternion.identity) as GameObject;
        previousPlatform = newPlatform.gameObject;
        Destroy(newPlatform, 7.0f);
        yield return new WaitForSeconds(spawnDelay);
        canSpawn = true;
    }

    /*
    This stops the SpawnPlatform from waiting around after respawning as this ended up creating unreachable platforms.
    */
    public void ResetSpawner()
    {
        StopAllCoroutines();
        previousPlatform = firstPlatform;
        canSpawn = true;
    }
}
