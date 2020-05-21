using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSonido : MonoBehaviour {
    private void Update () {
        //vamos con los controles
        if (Input.GetKeyUp (KeyCode.Joystick1Button2) || Input.GetKeyDown (KeyCode.Z)) {
            gameObject.GetComponent<ControladorDeAudio> ().AddPistaAudio ();
        }
        if (Input.GetKeyUp (KeyCode.Joystick1Button3) || Input.GetKeyDown (KeyCode.X)) {
            gameObject.GetComponent<ControladorDeAudio> ().AddPistaAudioOtros ();
        }
        if (Input.GetKeyUp (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Z)) {
            gameObject.GetComponent<ControladorDeAudio> ().AddPistaAudioOtrosMas ();
        }
    }

}