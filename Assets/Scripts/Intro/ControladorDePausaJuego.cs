using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDePausaJuego : MonoBehaviour {
    // Start is called before the first frame update

    private bool isPausa = true;
    public GameObject jugador;
    public GameObject camara1, camara2, pausa;
    // Update is called once per frame
    void Update () {
        if ((Input.GetKeyDown (KeyCode.C) || Input.GetKeyDown (KeyCode.Joystick1Button9)) && isPausa) {
            Pausar ();
        } else if ((Input.GetKeyDown (KeyCode.C) || Input.GetKeyDown (KeyCode.Joystick1Button9)) && !isPausa) {
            Reanudar ();
        }
    }
    public void Pausar () {
        int index;
        if (jugador.GetComponent<SpriteRenderer> ().sprite.name.Split ('_').Length <= 1) {
            index = 1;
        } else {
            index = int.Parse (jugador.GetComponent<SpriteRenderer> ().sprite.name.Split ('_') [1]); //si no lo combirte esposible que sea los sprinte de caminar
        }

        string indexString = index < 10 ? "0" + index.ToString () : index.ToString ();
        //ahora colocamos random la cara
        int randomCara = Random.Range (1, 4);
        string caraSeleccionada = "caras" + (randomCara >= 2 ? randomCara.ToString () : "") + "/caras" + ((randomCara >= 2 ? randomCara.ToString () : "") + indexString);
        Sprite spriteSeleccionada = Resources.Load<Sprite> (caraSeleccionada);
        jugador.GetComponent<SpriteRenderer> ().sprite = spriteSeleccionada;
        isPausa = false;
        camara2.SetActive (!isPausa);
        Time.timeScale = 0;
        //hacemos que el jugador no se pueda mover
        jugador.GetComponent<JoseController> ().QueNoSeMueva ();
        pausa.SetActive (!isPausa);
        jugador.GetComponent<Animator> ().enabled = isPausa;
    }
    public void Reanudar () {
        isPausa = true;
        camara2.SetActive (!isPausa);
        Time.timeScale = 1;
        pausa.SetActive (!isPausa);
        jugador.GetComponent<Animator> ().enabled = isPausa;
        jugador.GetComponent<JoseController> ().QueSeMueva ();
    }
}