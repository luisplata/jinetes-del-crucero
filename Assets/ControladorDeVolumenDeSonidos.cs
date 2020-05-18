using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeVolumenDeSonidos : MonoBehaviour {
    //Lo vamos a hacer con una lista de AudioSource para que los cambios se realicen de manera paralela con todos los cuestionados aqui
    public AudioSource pista1, pista2, pista3, pista4;
    public Slider slider;

    private float pista1Max, pista2Max, pista3Max, pista4Max;
    private float playerPref1, playerPref2, playerPref3, playerPref4;

    private void Start () {
        //vamos a consultar los valores guardados en playerpref
        if (PlayerPrefs.HasKey ("volumenGeneral")) {
            slider.value = PlayerPrefs.GetFloat ("volumenGeneral");
        } else {
            slider.value = 1;
        }
        CambioDeVolumenMejorado (slider.value);
        pista1Max = pista1.volume;
        pista2Max = pista2.volume;
        pista3Max = pista3.volume;
        pista4Max = pista4.volume;
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
        //guardamos en discoduro
        PlayerPrefs.SetFloat ("volumenGeneral", volumen);
    }
}