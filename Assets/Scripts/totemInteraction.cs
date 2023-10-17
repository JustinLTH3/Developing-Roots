using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totemInteraction : MonoBehaviour
{
    private bool interact = false;
    public EndOfGame eog;

    void Update()
    {
        if (interact && Input.GetKeyDown(KeyCode.E))
        {
            eog.EndGameScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interact = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            interact = false;
        }
    }
}
