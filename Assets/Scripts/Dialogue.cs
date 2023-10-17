using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //Who is talking.
    public string Name;
    [TextArea(3, 10)]
    //Contents that the Dialogue system show. They will be displayed one by one, according to the order.
    public List<string> contents;
}
