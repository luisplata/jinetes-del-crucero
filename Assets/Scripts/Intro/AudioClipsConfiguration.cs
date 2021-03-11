using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/AudioClipsConfiguration")]
public class AudioClipsConfiguration : ScriptableObject
{
    [SerializeField] private MusicClips[] musics;
    private Dictionary<string, MusicClips> idToPowerUp;

    private void Awake()
    {
        idToPowerUp = new Dictionary<string, MusicClips>(musics.Length);
        foreach (var music in musics)
        {
            idToPowerUp.Add(music.Id, music);
        }
    }

    public MusicClips GetMusicPrefabById(string id)
    {
        if (!idToPowerUp.TryGetValue(id, out var music))
        {
            throw new System.Exception($"Music with id {id} does not exit");
        }
        return music;
    }

    public MusicClips GetRandomPist()
    {
        return musics[Random.Range(0, musics.Length)];
    }
}