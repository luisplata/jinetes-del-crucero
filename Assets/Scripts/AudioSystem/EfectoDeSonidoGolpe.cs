using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoDeSonidoGolpe : MonoBehaviour {
    AudioSource reproductor;
    public List<AudioClip> listaDeGolpes, listaDePatadas, listaDePunio;

    private void Start () {
        reproductor = GetComponent<AudioSource> ();
    }
    //Clase encargada de reproducir los efectos de sonidos
    public void SonidoDeGolpe () {
        if (listaDeGolpes.Count <= 0) {
            throw new SonidoException ("No hay Audio para golpe");
        }
        reproductor.PlayOneShot (listaDeGolpes[Random.Range (0, this.listaDeGolpes.Count)]);
    }
    public void SonidoDePatada () {
        if (listaDePatadas.Count <= 0) {
            throw new SonidoException ("No hay Audio para la patada");
        }
        reproductor.PlayOneShot (listaDePatadas[Random.Range (0, this.listaDePatadas.Count)]);
    }

    public void SonidoDePunio () {
        if (listaDePunio.Count <= 0) {
            throw new SonidoException ("No hay Audio para el punio");
        }
        reproductor.PlayOneShot (listaDePunio[Random.Range (0, this.listaDePunio.Count)]);
    }
}