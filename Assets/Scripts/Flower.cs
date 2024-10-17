using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private ObjectiveController objectiveController;

    // Start is called before the first frame update
    void Start()
    {
        objectiveController = FindObjectOfType<ObjectiveController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player")) // if the player touches the flower
        {
            // make a new version of the flower and set the player as the parent
            // put it on its head
            objectiveController.hasObjective = true;
            wearHat(other.transform);
        }
    }

    private void wearHat(Transform playerTransform)
    {
        Transform bluePikminTransform = playerTransform.Find("Blue Pikmin");
        transform.SetParent(bluePikminTransform);
        //transform.localScale = playerTransform.localScale; // match the same scale as the player
        transform.localRotation = playerTransform.localRotation;
        transform.localPosition = new Vector3(0, 21f, 0);
    }
}
