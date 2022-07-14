using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Interaction { 
    jason_idle, 
    jason_idle_arrabbiato, 
    jason_idle_felice, 
    jason_idle_triste, 
    jason_int, 
    jason_int_annoiato,
    jason_int_arrabbiato,
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
    jason_tocco,
    JasonMDAnnoiato,
    JasonMDCamminata,
    JasonMDFelice,
    JasonMDNeutro,
    JasonMDPensieroso,
    JasonMDSpina1CheSparisce,
    JasonMDSpina2CheSparisce,
    JasonMDStupito,
    GattoCamminata,
    GattoCorsa,
    GattoFusa,
    GattoIdleArrabbiato,
    GattoIdleFelice,
    GattoIdleNeutro,
    GattoIdleTriste,
    GattoIntFelice,
    GattoIntNeutro,
    GattoIntTriste,
    GattoIntArrabbiato,
    GattoSeduto,
    GattoSiAlza,
    GattoSiSiede,
    bonnie_idle,
    bonnie_int_arrabbiata,
    bonnie_int_felice,
    bonnie_int_normale,
    bonnie_int_triste,
    finn_idle,
    finn_int_felice,
    finn_int_normale,
    finn_int_triste,
    katy_appoggia_tazzina,
    katy_camminataNocaffe,
    katy_camminata_caffe,
    katy_idle,
    katy_int_felice,
    katy_int_normale,
    katy_int_triste,
    katy_occhiolino

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
