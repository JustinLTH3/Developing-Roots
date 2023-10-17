using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    //the gameobject that show the dialogue.
    [SerializeField] GameObject frame;
    //Display the content of dialogue.
    [SerializeField] TMP_Text dialogue;
    //Display who is talking
    [SerializeField] TMP_Text nameDisplay;
    //It tells if the system is in use.
    public bool Talking { get => frame.activeSelf; }
    public static DialogueSystem Instance { get; private set; }

    private void Start()
    {
        if (Instance != this && Instance != null) Destroy(gameObject);
        Instance = this;
    }
    
    public bool StartDialogue(Dialogue dialogue)
    {
        //only start if the system is not in use
        if (Talking) return false;
        nameDisplay.text = dialogue.Name + ":";
        StartCoroutine(StartDialogue(dialogue.contents));
        return true;
    }
    IEnumerator StartDialogue(List<string> Contents)
    {
        frame.SetActive(true);
        while (true)
        {//wait for continue
            yield return StartCoroutine(StartDialogue(Contents[0]));
            Contents.RemoveAt(0);
            if (Contents.Count == 0) break;
            yield return null;
        }
        frame.SetActive(false);
    }
    //For Only one line of content
    IEnumerator StartDialogue(string content)
    {
        dialogue.text = content;
        while (true)
        {
            //press any key to continue the dialogue
            //wait for key press
            if (Input.anyKeyDown)
            {
                break;
            }
            yield return null;
        }
    }
}

