using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSonido : MonoBehaviour {
    private void Update () {
        //vamos con los controles
        if (Input.GetKeyUp (KeyCode.Joystick1Button2)) {
            gameObject.GetComponent<ControladorDeAudio> ().AddPistaAudio ();
        }
        if (Input.GetKeyUp (KeyCode.Joystick1Button3)) {
            gameObject.GetComponent<ControladorDeAudio> ().AddPistaAudioOtros ();
        }
        if (Input.GetKeyUp (KeyCode.Joystick1Button1)) {
            gameObject.GetComponent<ControladorDeAudio> ().AddPistaAudioOtrosMas ();
        }
    }

}