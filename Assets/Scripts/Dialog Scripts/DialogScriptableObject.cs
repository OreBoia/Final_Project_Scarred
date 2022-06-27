using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Interaction { jason_idle, jason_idle_arrabbiato, jason_idle_felice, jason_idle_triste }
public enum BubblePosition { Right, Left}

public class DialogScriptableObject : ScriptableObject
{
    [System.Serializable]
    public class DialogString
    {
        public string sentence;
        public int id;
        public Interaction interaction;
        public Color colorFrame;
        public Color colorText;
        public BubblePosition bubblePosition;
    }

    public List<DialogString> strings = new List<DialogString>();

}
