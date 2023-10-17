using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectablePool : MonoBehaviour
{
    public GameObject objects; //Prefab gameobject to clone
    public int poolSize; //Number of clones of the prefab
    public Dictionary<GameObject, bool> pool = new Dictionary<GameObject, bool>(); //Dictionary collection to store clones. Bool to state if they are ready
    private GameObject selectedGameobject; //Hold selected prefab
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public Transform tempPosition; //Temp position when not in scene

    void Start()
    {
        for (int i = 0; i < poolSize; i++) //loop to create each prefab clone on load of game
        {
            GameObject obj = (GameObject)Instantiate(objects, tempPosition.position, objects.transform.rotation); //Instantiate Object
            pool.Add(obj, true); //Add to dictionary
        }
    }

    public void SpawnCollectable()
    {
        float xChoice = Random.Range(minX, maxX); //random choice of x
        float yChoice = Random.Range(minY, maxY); //random choice of y
        foreach (KeyValuePair<GameObject, bool> obj in pool) //Foreach loop to check which prefab clone is ready
        {
            if (obj.Value == true) //if a ready prefab clone is found
            {
                selectedGameobject = obj.Key; //store the prefab
                break; //break out of the loop
            }
        }

        pool[selectedGameobject] = false; //Set ready as false for the prefab in the dictionary
        selectedGameobject.transform.position = new Vector2(xChoice, yChoice); //set the objects position 

    }

    public void ReturnCollectable(GameObject item)
    {
        item.transform.position = tempPosition.position; //Set the objects position back
        pool[item] = true; //Set ready as true in dictionary
    }
}
