using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour {
    //Cambio de Escena
    public void CambioDeEscenaJuego () {
        SceneManager.LoadScene ("Intro");
    }

    public GameObject creditos;
    public void ColocandoCreditos () {
        GetComponent<Animator> ().SetTrigger ("salir");
        creditos.setActive (true);
    }
}