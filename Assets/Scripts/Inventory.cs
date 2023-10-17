using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one inventory!");
            return;
        }
        instance = this;
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public delegate void OnItemRid();
    public OnItemRid onItemRidCallback;

    public int slots = 20;
    public int numOfMissionsDone = 0;
    private int numOfMissionsTotal = 3;
    public EndOfGame eog;
    public static List<GameObject> colItems = new List<GameObject>();

    public bool add(GameObject item)
    {
        //if (!item.defaut)
        //{
        if (colItems.Count >= slots)
        {
            Debug.Log("Too many items!");
            return false;
        }
        colItems.Add(item);
        
        if (onItemChangedCallback != null) { 
            onItemChangedCallback.Invoke();
        }
        return true;
        //}
    }

    public void remove(GameObject item)
    {
        colItems.Remove(item);

        if (onItemRidCallback != null)
        {
            onItemRidCallback.Invoke();
        }
    }

    public void checkFin()
    {
        numOfMissionsDone += 1;
        if (numOfMissionsDone == numOfMissionsTotal)
        {
            eog.totemAppear();
            Debug.Log("Done all missions!");
        }
    }
}
