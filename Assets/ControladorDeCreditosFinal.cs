using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeCreditosFinal : MonoBehaviour {
    public GameObject creditos;
    public float velocidad;
    // Update is called once per frame
    void Update () {
        creditos.transform.position += new Vector3 (0, velocidad * Time.deltaTime, 0);
    }
}