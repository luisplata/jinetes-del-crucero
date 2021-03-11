using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeSonido : MonoBehaviour {
    private IAudioSystem audioSystem;
    private void Start()
    {
        audioSystem = GetComponent<IAudioSystem>();
    }
    private void Update () {
        //vamos con los controles
        if (Input.GetKeyUp (KeyCode.Joystick1Button2) || Input.GetKeyDown (KeyCode.Z)) {
            audioSystem.PlayById(1);
        }
        if (Input.GetKeyUp (KeyCode.Joystick1Button3) || Input.GetKeyDown (KeyCode.X)) {
            audioSystem.PlayById(2);
        }
        if (Input.GetKeyUp (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Z)) {
            audioSystem.PlayById(3);
        }
    }

}