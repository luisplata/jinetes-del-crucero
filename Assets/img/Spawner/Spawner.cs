using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject enemigo;
    private GameObject enemigoModificado;
    ControladorDelMundo controladorDeMundo;
    private void Start () {
        controladorDeMundo = GameObject.Find ("ControladorDelMundo").GetComponent<ControladorDelMundo> ();
    }
    public void SpawnearEnemigo () {
        if (controladorDeMundo.EnemigosFaltantes () > controladorDeMundo.EnemigosSumados () && controladorDeMundo.EnemigosSumados () < 16) {
            EnemigoControlador controaldorDeEnemigo = Instantiate (enemigo, transform).GetComponent<EnemigoControlador> ();
            controaldorDeEnemigo.QueLoHagaTodo ();
            controaldorDeEnemigo.oleadaPerteneciente = controladorDeMundo.OleadaActual () - 1;
            controladorDeMundo.SpawnEnemigo ();
        }
    }

    public void PrimerEnemigo () {
        controladorDeMundo = GameObject.Find ("ControladorDelMundo").GetComponent<ControladorDelMundo> ();
        //creamos al primer enemigo
        enemigoModificado = Instantiate (enemigo, transform);
        //le quitamos algunos componentes
        enemigoModificado.GetComponent<EnemigoControlador> ().QueNoHagaNada ();
        controladorDeMundo.SpawnEnemigo ();
    }

}