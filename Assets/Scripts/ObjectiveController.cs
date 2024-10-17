using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    public GameObject flowerPrefab;
    public GameObject player;
    //public GameObject hat;

    public List<Vector3> validSpawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        spawnFlower();
    }

    private void spawnFlower()
    {
        if (validSpawnLocations.Count > 0)
        {
            // choose a random location, and spawn the flower in that area
            Vector3 spawnLocation = validSpawnLocations[Random.Range(0, validSpawnLocations.Count)];
            Instantiate(flowerPrefab, spawnLocation, Quaternion.identity);
        } else
        {
            Debug.Log("put in spawn locations please");
        }
    }

    private void onTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if the player touches the flower
        {
            // make a new version of the flower and set the player as the parent
            // put it on its head
            wearHat(other.transform);

            //Destroy(gameObject); 
        }
    }

    private void wearHat(Transform playerTransform)
    {
        transform.SetParent(playerTransform);
        transform.localScale = playerTransform.localScale; // match the same scale as the player
        transform.localRotation = playerTransform.localRotation;
        transform.localPosition = new Vector3(0, 21f, 0);

    }
}
