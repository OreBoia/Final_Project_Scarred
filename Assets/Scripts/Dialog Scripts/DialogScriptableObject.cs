using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Interaction 
{ 
    jason_idle, 
    jason_idle_arrabbiato, 
    jason_idle_felice, 
    jason_idle_triste, 
    jason_int, 
    jason_int_annoiato, 
    jason_int_felice,
    jason_int_pensieroso,
    jason_int_seduto,
    jason_int_sorpreso,
    jason_int_triste,
    jason_caffeCasa_beve,
    jason_caffeCasa_giu,
    jason_caffeCasa_su,
    jason_cell_alto_giu,
    jason_cell_alto_su,
    jason_cell_basso_giu,
    jason_cell_basso_su,
    jason_cell_guarda,
    jason_cell_risponde,
    jason_letto_dorme,
    jason_letto_si_sveglia,
    jason_seduto,
    jason_seduto_beve_caffe,
    jason_seduto_giu,
    jason_seduto_su,
    jason_tocco
}
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
