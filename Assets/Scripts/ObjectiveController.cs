using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour
{
    public GameObject flowerPrefab;
    //public GameObject hat;
    public bool hasObjective = false;

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
}
