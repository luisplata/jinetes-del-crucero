using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControladorDeDialogo : MonoBehaviour {
    public GameObject player, dialogoSprite;
    public int dialogo;
    List<string> dialogos;
    public TextMeshProUGUI texto;

    private bool seActivo = false;
    private void Start () {
        dialogos = new List<string> ();
        dialogos.Add ("Que fiesta la de hoy! vayamos para la casa");
        dialogos.Add ("Esta caneca que hace aquí? Como que con X o Z la puedo romper?");
        dialogos.Add ("jajajaja eso fue divertido");
        dialogos.Add ("Hay mas de esas cosas?! ya verán!");
        dialogos.Add ("jajajaja que divertido fue eso...");
        dialogos.Add ("Como que con C coloco Pausa!");
        dialogos.Add ("hola como estas es una prueba de cuanto texto puedo colocar");
    }
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.transform.CompareTag ("Player")) {
            //iniciamos el dialogo
            if (!seActivo) {
                StartCoroutine ("ActivacionDeDialogos");
                seActivo = true;
            }
        }
    }
    IEnumerator ActivacionDeDialogos () {
        Debug.Log("Activo los dialogos?");
        texto.text = dialogos[dialogo];
        dialogoSprite.SetActive (true);
        //dialogoSprite.transform.position = new Vector3 (6, 6, 0);
        yield return new WaitForSeconds (4);
        dialogoSprite.SetActive (false);
    }
}