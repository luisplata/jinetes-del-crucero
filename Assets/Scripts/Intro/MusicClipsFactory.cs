using UnityEngine;

public class MusicClipsFactory
{
    private readonly AudioClipsConfiguration musicClipsConfiguration;

    public MusicClipsFactory(AudioClipsConfiguration musicClipsConfiguration)
    {
        this.musicClipsConfiguration = musicClipsConfiguration;
    }

    public MusicClips Create(string id)
    {
        var prefab = musicClipsConfiguration.GetMusicPrefabById(id);

        return Object.Instantiate(prefab);
    }
}