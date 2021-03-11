public class MusicClipsSpawner
{
    private readonly MusicClipsFactory musicFactory;
    private readonly IAudioSystemView audioSystenView;
    public delegate void AddSound(UnityEngine.AudioClip audio);
    private readonly AddSound add;
    public MusicClipsSpawner(MusicClipsFactory musicFactory, IAudioSystemView audioSystenView, AddSound addSound)
    {
        this.musicFactory = musicFactory;
        this.audioSystenView = audioSystenView;
        add = addSound;
    }

    // Logic

    public void SpawnMusicClip(string id)
    {
        var s = musicFactory.Create(id);
        add(s.Audio);
        //TODO hacer que suene con la interfas de la vista
        audioSystenView.DestroyObject(s.gameObject);
    }
}