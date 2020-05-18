using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MandarloAPantallaDeGame : MonoBehaviour {
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.transform.CompareTag ("Player")) {
            //lo mandamos a la pantalla de juego
            SceneManager.LoadScene ("Game");
        }
    }
}