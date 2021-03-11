using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour {
    //Variables
    private int oleadaActual, oleadaFinal, enemigosActuales;
    private float tiempo;
    private string tiempoFormato, oleadaFormato, enemigoFormato;
    //elementosParaAfectar
    public TextMeshProUGUI tiempoUI, OleadaUI, enemigosUI, oleada;
    // Start is called before the first frame update
    void Start () {
        oleadaActual = 1;
        oleadaFinal = 10;
    }

    // Update is called once per frame
    void Update () {
        tiempo += Time.deltaTime;
        //Debug.Log ("tiempo " + tiempo);
        tiempoFormato = string.Format ("Tiempo: {0} Seg", (int) tiempo);
        oleadaFormato = string.Format ("{0}/{1}", oleadaActual, oleadaFinal);
        enemigoFormato = string.Format ("Enemigos: {0}", enemigosActuales);

        tiempoUI.text = tiempoFormato;
        OleadaUI.text = oleadaFormato;
        enemigosUI.text = enemigoFormato;
    }

    public void ActualizarEnemigos (int cantidad) {
        this.enemigosActuales = cantidad;
    }
    public void ActualizarTiempo (int tiempoActual) {
        this.tiempo = tiempoActual;
    }

    public void ActualizarOleada () {
        this.oleadaActual++;
    }
}