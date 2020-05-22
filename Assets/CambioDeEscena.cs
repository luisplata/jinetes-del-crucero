using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour {
    //Cambio de Escena
    public GameObject creditos, textos;
    public void CambioDeEscenaJuego () {
        SceneManager.LoadScene ("Intro");
    }

    public void ColocandoCreditos () {
        creditos.SetActive (true);

        textos.transform.position = new Vector3 (266, -220, 0);
    }

    public void PlayMusic () {
        GetComponent<AudioSource> ().Play ();
    }
}