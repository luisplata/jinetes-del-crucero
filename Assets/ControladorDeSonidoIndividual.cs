using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSonidoIndividual : MonoBehaviour {
    public AudioSource pista1;
    private float pista1Max;
    private float volumenFlotante;
    // Start is called before the first frame update
    void Start () {
        pista1Max = pista1.volume;
        if (PlayerPrefs.HasKey ("volumenGeneral")) {
            float numeroFlotante = (float) PlayerPrefs.GetInt ("volumenGeneral");
            volumenFlotante = numeroFlotante / 100;
        } else {
            volumenFlotante = 1;
        }
        pista1.volume = volumenFlotante * pista1Max;

    }
}