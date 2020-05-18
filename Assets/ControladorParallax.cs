using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorParallax : MonoBehaviour {
    public RawImage cielo, edificios, pasto, piso, paredFondo, faroles;
    [SerializeField]
    private float speed = 0.007f;

    // Update is called once per frame
    void Update () {
        float velocidadPara = speed * Time.deltaTime;
        cielo.uvRect = new Rect (cielo.uvRect.x + (velocidadPara / 4), 0f, 1f, 1f);
        edificios.uvRect = new Rect (edificios.uvRect.x + velocidadPara * 3, 0f, 1f, 1f);
        paredFondo.uvRect = new Rect (pasto.uvRect.x + velocidadPara * 2.5f, 0f, 1f, 1f);
        pasto.uvRect = new Rect (pasto.uvRect.x + velocidadPara * 2, 0f, 1f, 1f);
        faroles.uvRect = new Rect (pasto.uvRect.x + velocidadPara * 1.8f, 0f, 1f, 1f);
        piso.uvRect = new Rect (piso.uvRect.x + velocidadPara, 0f, 1f, 1f);
    }
    public void Salir () {
        Application.Quit ();
    }
}