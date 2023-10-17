using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    public GameObject player;
    private bool pickUpAllowed;
    public GameObject tempPos;
    public CollectablePool cp;
    public GameObject item;

    // Use this for initialization
    private void Start()
    {
        player = GameObject.Find("Player");
        item = this.gameObject;
        string tempString = item.transform.name.Split('(')[0];
        Debug.Log(tempString);
        if (item.tag != "Photo") tempPos = GameObject.FindWithTag(tempString);
        else tempPos = GameObject.Find("picBin");
        cp = tempPos.GetComponent<CollectablePool>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp(item);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pickUpAllowed = true; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = false;
        }
    }

    private void PickUp(GameObject item)
    {
        bool collected = Inventory.instance.add(item);
        if (collected)
        {
            cp.ReturnCollectable(item);
        }
    }

    public void give()
    {
        Debug.Log("Giving" + item.transform.name.Split('(')[0]);
        Inventory.instance.remove(item);
    }
}