using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarSangreEnPared : MonoBehaviour {
    public GameObject sangre1, sangre2, sangre3;
    public void ColocarSangre () {
        Instantiate (sangre1, transform);
    }
}