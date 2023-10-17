using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Image oldIcon;
    public GameObject oldItem;
    public GameObject item;
    public Collecting collect;
    public int itemNum;

    void Start()
    {
        item = oldItem;
        collect = item.GetComponent<Collecting>();
    }

    public void addItem(GameObject newItem)
    {
        item = newItem;
        icon.sprite = item.GetComponent<SpriteRenderer>().sprite;
        icon.enabled = true;
    }

    public void clearSlot()
    {
        item = oldItem;

        icon.sprite = oldIcon.sprite;
        icon.enabled = false;
    }

}
