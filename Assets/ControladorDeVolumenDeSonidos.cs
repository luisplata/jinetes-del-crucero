using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeVolumenDeSonidos : MonoBehaviour {
    //Lo vamos a hacer con una lista de AudioSource para que los cambios se realicen de manera paralela con todos los cuestionados aqui
    public AudioSource pista1, pista2, pista3, pista4, pista5;
    public Slider slider;
    //[SerializeField]
    private float pista1Max, pista2Max, pista3Max, pista4Max, pista5Max;

    float volumenFlotante;
    private void Start () {
        pista1Max = pista1.volume;
        pista2Max = pista2.volume;
        pista3Max = pista3.volume;
        pista4Max = pista4.volume;
        pista5Max = pista5.volume;
        //vamos a consultar los valores guardados en playerpref
        if (PlayerPrefs.HasKey ("volumenGeneral")) {
            float numeroFlotante = (float) PlayerPrefs.GetInt ("volumenGeneral");
            volumenFlotante = numeroFlotante / 100;
        } else {
            volumenFlotante = 1;
        }
        CambioDeVolumenMejorado (volumenFlotante);
        slider.value = volumenFlotante;
    }
    public void CambioDeVolumen () {
        CambioDeVolumenMejorado (slider.value);
    }

    private void CambioDeVolumenMejorado (float volumen) {
        //tomamos el 100% de los audios
        pista1.volume = volumen * pista1Max;
        pista2.volume = volumen * pista2Max;
        pista3.volume = volumen * pista3Max;
        pista4.volume = volumen * pista4Max;
        pista5.volume = volumen * pista5Max;
        //guardamos en discoduro
        PlayerPrefs.SetInt ("volumenGeneral", (int) (volumen * 100));
    }
}