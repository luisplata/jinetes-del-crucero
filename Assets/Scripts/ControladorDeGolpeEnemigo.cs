using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeGolpeEnemigo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<JoseController>().RestarVida();
            gameObject.transform.parent.GetComponent<EnemigoControlador>().IrseDelObjetivo ();
        }
    }
}
