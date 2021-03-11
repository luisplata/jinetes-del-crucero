using System;
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

    private bool soloUnaVez;
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            Application.Quit ();
        }
        if (audioComponent.time + Time.deltaTime > audioComponent.clip.length) {

            vueltas = CheckTheAuduiFinish(vueltas, listaDeClips, audioSonar, audioComponentPista2);
            vueltasOtros = CheckTheAuduiFinish(vueltasOtros, listaDeClipsOtros, audioSonarOtros, audioComponentPista1);
            vueltasOtrosMas = CheckTheAuduiFinish(vueltasOtrosMas, listaDeClipsOtrosMas, audioSonarOtrosMas, audioComponentPista3);
            audioComponent.time = 0;
        }
    }

    private float CheckTheAuduiFinish(float loop, List<AudioClip> list, AudioClip audio, AudioSource audioSource)
    {
        loop--;
        if (list.Count > 0 && loop <= 0)
        {
            if (audio)
            {
                audio.UnloadAudioData();
            }
            audio = list[0];
            loop = Mathf.Ceil(audio.length / audioSource.clip.length);
            audioSource.PlayOneShot(audio);
            list.Remove(audio);
        }
        return loop;
    }

    public void AddPistaAudio (AudioClip audio) {
        listaDeClips.Add (audio);
    }
    public void AddPistaAudioOtros (AudioClip audio) {
        listaDeClipsOtros.Add (audio);
    }
    public void AddPistaAudioOtrosMas (AudioClip audio) {
        listaDeClipsOtrosMas.Add (audio);
    }
}
