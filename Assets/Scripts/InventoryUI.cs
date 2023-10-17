using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{

    public Transform invSlots;
    public InventorySlot[] slots;
    Inventory inv;
    public Missions[] missionList;
    public Collecting collect;
    public GameObject empty;

    // Start is called before the first frame update
    void Start()
    {
        inv = Inventory.instance;
        inv.onItemChangedCallback += updateUI;
        inv.onItemRidCallback += updateUIRid;

        slots = invSlots.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void updateUI()
    {
        int temp = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < Inventory.colItems.Count)
            {
                slots[i].addItem(Inventory.colItems[i]);
                temp = i; 
            }
            else
            {
                slots[i].clearSlot();
            }
        }

        if (Inventory.colItems[temp].tag ==  "NPC1")
            missionList[0].updateMission();
        else if (Inventory.colItems[temp].tag == "NPC2")   
            missionList[1].updateMission();
        else if (Inventory.colItems[temp].tag == "NPC3")
            missionList[2].updateMission();
    }

    void updateUIRid()
    {
        int temp = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.colItems.Count)
            {
                slots[i].addItem(Inventory.colItems[i]);
                temp = i;
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }

    public void giveItems(string tag)
    {
        int temp = 0;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[0].item.name == empty.name)
            {
                break;
            }
            else if (Inventory.colItems[temp].tag == tag)
            {
                collect = Inventory.colItems[temp].GetComponent<Collecting>();
                collect.give();
            }
            else temp += 1;
        }
    }

    public void endRemove()
    {
        for (int i = 0; i < 4; i++)
        {
            if (slots[0].item.name == empty.name)
            {
                break;
            }
            collect = Inventory.colItems[0].GetComponent<Collecting>();
            collect.give();
        }
    }
}
