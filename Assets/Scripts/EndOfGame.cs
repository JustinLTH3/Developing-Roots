using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    public GameObject totem;
    public GameObject endText;
    //public StartCutScene sc;
    public bool check;
    public InventoryUI inv;

    void Update()
    {
        if (check == true)
        {
            inv.endRemove();
            SceneManager.LoadScene(0);
        }
    }

    public void totemAppear()
    {
        totem.SetActive(true);
    }

    public void EndGameScreen()
    {
        endText.SetActive(true);
        Debug.Log("Game will end - go back to main menu...");
    }
}
