using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour {
    //Cambio de Escena
    public void CambioDeEscenaJuego () {
        SceneManager.LoadScene ("Intro");
    }
}