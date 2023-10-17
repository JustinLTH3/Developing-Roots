using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    //Dialogue of Start mission and Complete mission
    [SerializeField] Dialogue startDialogue, completeDialogue;
    //have the npc given the task to the player
    bool givedTask = false;
    //is the mission completed, and has successfully start dialogue
    public bool isMissionCompleted = false;
    [SerializeField] Player player;
    public Missions mission;
    public InventoryUI inv;
    public GameObject photo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == player.gameObject.name && !givedTask)
        {
            givedTask = DialogueSystem.Instance.StartDialogue(startDialogue);
            mission.startMission();
        }
        else if (collision.name == player.gameObject.name && mission.numCollected == mission.TotalnumOfItems
            && !isMissionCompleted && mission.gameObject.name == this.gameObject.tag)
        {
            isMissionCompleted = DialogueSystem.Instance.StartDialogue(completeDialogue);
            player.FinishedTask = false;
            Inventory.instance.checkFin();
            photo.SetActive(true);
            inv.giveItems(this.gameObject.name);
        }
    }
}
