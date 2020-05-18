using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeadorDeEnemigos : MonoBehaviour {
    private void OnCollisionEnter2D (Collision2D other) {
        EfectoDeSonidoGolpe controladorDeSonido;
        if (other.gameObject.CompareTag ("Enemigo")) {
            try {
                controladorDeSonido = GameObject.Find ("Sonidos").GetComponent<EfectoDeSonidoGolpe> ();
                if (this.gameObject.CompareTag ("golpeSuave") && other.gameObject.CompareTag ("Enemigo")) {
                    other.gameObject.GetComponent<InterfaceParaCosaGolpeable> ().RestarVida (gameObject.transform.parent.GetComponent<JoseController> ().GetGolpeSuave ());
                    controladorDeSonido.SonidoDePunio ();
                }
                if (this.gameObject.CompareTag ("Patada") && other.gameObject.CompareTag ("Enemigo")) {
                    other.gameObject.GetComponent<InterfaceParaCosaGolpeable> ().RestarVida (gameObject.transform.parent.GetComponent<JoseController> ().GetGolpeDuro ());
                    controladorDeSonido.SonidoDePatada ();
                }

                if (other.gameObject.GetComponent<InterfaceParaCosaGolpeable> ().GetSalud () <= 0 && other.gameObject.CompareTag ("Enemigo")) {
                    other.gameObject.GetComponent<InterfaceParaCosaGolpeable> ().MorirEnemigo ();
                    controladorDeSonido.SonidoDeGolpe ();
                }
            } catch (SonidoException e) {
                Debug.Log (e.ToString ());
            }
        }
    }
}