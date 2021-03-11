using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour, IAudioSystem, IAudioSystemView
{
    [SerializeField] private AudioClipsConfiguration clips1, clips2, clips3;
    private MusicClipsFactory MusicFactory1, MusicFactory2, MusicFactory3;
    private MusicClipsSpawner MusicSpawner1, MusicSpawner2, MusicSpawner3;
    [SerializeField] ControladorDeAudio audioController;

    private void Start()
    {
        MusicFactory1 = new MusicClipsFactory(Instantiate(clips1));
        MusicFactory2 = new MusicClipsFactory(Instantiate(clips2));
        MusicFactory3 = new MusicClipsFactory(Instantiate(clips3));
        MusicSpawner1 = new MusicClipsSpawner(MusicFactory1, this, audioController.AddPistaAudio);
        MusicSpawner2 = new MusicClipsSpawner(MusicFactory2, this, audioController.AddPistaAudioOtros);
        MusicSpawner3 = new MusicClipsSpawner(MusicFactory3, this, audioController.AddPistaAudioOtrosMas);
    }

    /// <summary>
    /// return 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="deep">This param load the sound in pist 1 or 2 or 3</param>
    public void PlayById(int deep)
    {
        string id;
        switch (deep)
        {
            case 1:
                id = clips1.GetRandomPist().Id;
                MusicSpawner1.SpawnMusicClip(id);
                break;
            case 2:
                id = clips2.GetRandomPist().Id;
                MusicSpawner2.SpawnMusicClip(id);
                break;
            case 3:
                id = clips3.GetRandomPist().Id;
                MusicSpawner3.SpawnMusicClip(id);
                break;
            default:
                Debug.LogError($"the deep {deep} is not exist!");
                break;
        }
    }

    public void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
