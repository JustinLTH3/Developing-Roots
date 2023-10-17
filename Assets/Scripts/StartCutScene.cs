using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutScene : MonoBehaviour
{
    //Start when the object loaded
    //destroy when All dialogue are shown
    public List<Dialogue> dialogue = new();
    public EndOfGame eog;

    private void Awake()
    {
        StartCoroutine(StartSceneDialogue());
    }
    IEnumerator StartSceneDialogue()
    {
        yield return null;
        while (true)
        {
            if (dialogue.Count == 0) break;
            while (!DialogueSystem.Instance.StartDialogue(dialogue[0]))
            {
                yield return null;
            }
            dialogue.RemoveAt(0);
            yield return null;
        }
        while (DialogueSystem.Instance.Talking)
        {
            yield return null;
        }
        if (this.gameObject.tag == "Finish") eog.check = true;
        gameObject.SetActive(false);
    }
}
