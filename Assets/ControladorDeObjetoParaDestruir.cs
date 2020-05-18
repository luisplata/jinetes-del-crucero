using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeObjetoParaDestruir : MonoBehaviour, InterfaceParaCosaGolpeable {
    float salud = 10;

    public void RestarVida (int vida) {
        salud -= vida;
        //lo que vamos a hacer es cambiar el sprite del golpeado
        Debug.Log ("Fue golpeado");
        GetComponent<Animator> ().SetTrigger ("golpeado");
    }
    public void MorirEnemigo () {
        //Debug.Log ("Se murio");
        GetComponent<Animator> ().SetTrigger ("morir");
    }

    public float GetSalud () {
        return salud;
    }

    public void Morir () {
        //Destroy (gameObject);
        //Desactivamos los colicionadores y el rigibody
        Destroy (GetComponent<Rigidbody2D>());
        Destroy (GetComponent<BoxCollider2D>());
    }

    public void QuitarRogiBody () {
        Destroy (GetComponent<BoxCollider2D> ());
        Destroy (GetComponent<Rigidbody2D> ());
    }
}