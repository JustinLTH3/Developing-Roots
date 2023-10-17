using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missions : MonoBehaviour
{
    public int TotalnumOfItems;
    public int numCollected;
    public CollectablePool cp;
    public Player player;


    public void startMission()
    {
        for (int i = 0; i < TotalnumOfItems; i++) {
            cp.SpawnCollectable();
        }
    }

    public void updateMission()
    {
        numCollected += 1;
        if (numCollected == TotalnumOfItems)
        {
            endMission();
        }
    }

    public void endMission()
    {
        player.FinishedTask = true;
    }
}
