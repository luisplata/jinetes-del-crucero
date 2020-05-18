using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ControladorDeAudio : MonoBehaviour {
    public AudioSource audioComponentPista2, audioComponentPista1, audioComponentPista3;
    private AudioSource audioComponent;
    [SerializeField]
    private List<AudioClip> listaDeClips = new List<AudioClip> ();
    [SerializeField]
    private List<AudioClip> listaDeClipsOtros = new List<AudioClip> ();
    [SerializeField]
    private List<AudioClip> listaDeClipsOtrosMas = new List<AudioClip> (); //Listas para reproduccir

    public List<AudioClip> listaDeAudiosPrincipales, listaDeAudiosSecundarios, listaDeAudiosTerciaros; //Lista de recursos
    private AudioClip audioSonar, audioSonarOtros, audioSonarOtrosMas;
    // Start is called before the first frame update
    void Start () {
        audioComponent = GetComponent<AudioSource> ();
    }
    //necesitamos saber cuantas vueltas de bocle necesitamos para reproducir el audio de efecto.
    float vueltas, vueltasOtros, vueltasOtrosMas;
    int contadorVueltas;

    private bool soloUnaVez;
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            Application.Quit ();
        }
        if (audioComponent.time + Time.deltaTime > audioComponent.clip.length) {
            vueltas--;
            if (listaDeClips.Count > 0 && vueltas <= 0) {
                if (audioSonar) {
                    audioSonar.UnloadAudioData ();
                }
                audioSonar = listaDeClips[0];
                vueltas = Mathf.Ceil (audioSonar.length / audioComponent.clip.length);
                audioComponentPista2.PlayOneShot (audioSonar);
                listaDeClips.Remove (audioSonar);
            }

            //segunda pista

            vueltasOtros--;
            if (listaDeClipsOtros.Count > 0 && vueltasOtros <= 0) {
                if (audioSonarOtros) {
                    audioSonarOtros.UnloadAudioData ();
                }
                audioSonarOtros = listaDeClipsOtros[0];
                vueltasOtros = Mathf.Ceil (audioSonarOtros.length / audioComponent.clip.length);
                audioComponentPista1.PlayOneShot (audioSonarOtros);
                listaDeClipsOtros.Remove (audioSonarOtros);
            }

            vueltasOtrosMas--;
            if (listaDeClipsOtrosMas.Count > 0 && vueltasOtrosMas <= 0) {
                if (audioSonarOtrosMas) {
                    audioSonarOtrosMas.UnloadAudioData ();
                }
                audioSonarOtrosMas = listaDeClipsOtrosMas[0];
                vueltasOtrosMas = Mathf.Ceil (audioSonarOtrosMas.length / audioComponent.clip.length);
                audioComponentPista3.PlayOneShot (audioSonarOtrosMas);
                listaDeClipsOtrosMas.Remove (audioSonarOtrosMas);
            }

            audioComponent.time = 0;
        }
    }

    public void AddPistaAudio (AudioClip audio) {
        listaDeClips.Add (audio);
    }
    public void AddPistaAudio () {
        listaDeClips.Add (GetAudioRandom ());
    }
    public void AddPistaAudioOtros (AudioClip audio) {
        listaDeClipsOtros.Add (GetAudioSecundarioRandom ());
    }
    public void AddPistaAudioOtros () {
        listaDeClipsOtros.Add (GetAudioSecundarioRandom ());
    }
    //Cualquiera
    public void AddPistaAudioOtrosMas (AudioClip audio) {
        listaDeClipsOtrosMas.Add (audio);
    }
    //Random
    public void AddPistaAudioOtrosMas () {
        listaDeClipsOtrosMas.Add (GetAudioTerciarioRandom ());
    }

    public AudioClip GetAudio () {
        return GetAudio (0);
    }
    public AudioClip GetAudioRandom () {
        if (this.listaDeAudiosPrincipales.Count > 0) {
            return GetAudio (Random.Range (0, this.listaDeAudiosPrincipales.Count));
        } else {
            return GetAudio (0);
        }
    }
    public AudioClip GetAudio (int index) {
        if (listaDeAudiosPrincipales.Count <= 0) {
            throw new SonidoException ("No hay audios que entregar");
        }
        return listaDeAudiosPrincipales[index];
    }
    public int GetAudioSize () {
        return this.listaDeAudiosPrincipales.Count;
    }
    public AudioClip GetAudioSecundario () {
        return GetAudioSecundario (0);
    }
    public AudioClip GetAudioSecundarioRandom () {
        if (this.listaDeAudiosSecundarios.Count > 0) {
            return GetAudioSecundario (Random.Range (0, this.listaDeAudiosSecundarios.Count));
        } else {
            return GetAudioSecundario (0);
        }
    }
    public AudioClip GetAudioSecundario (int index) {
        if (listaDeAudiosSecundarios.Count <= 0) {
            throw new SonidoException ("No hay audios que entregar");
        }
        return listaDeAudiosSecundarios[index];
    }
    public int GetAudioSecundarioSize () {
        return this.listaDeAudiosSecundarios.Count;
    }
    public AudioClip GetAudioTerciario () {
        return GetAudioTerciario (0);
    }
    public AudioClip GetAudioTerciarioRandom () {
        if (this.listaDeAudiosTerciaros.Count > 0) {
            return GetAudioTerciario (Random.Range (0, this.listaDeAudiosTerciaros.Count));
        } else {
            return GetAudioTerciario (0);
        }
    }
    public AudioClip GetAudioTerciario (int index) {
        if (listaDeAudiosTerciaros.Count <= 0) {
            throw new SonidoException ("No hay audios que entregar");
        }
        return listaDeAudiosTerciaros[index];
    }
    public int GetAudioTerciarioSize () {
        return this.listaDeAudiosTerciaros.Count;
    }
}