using UnityEngine;

public abstract class MusicClips : MonoBehaviour
{
    [SerializeField] protected string id;
    [SerializeField] private AudioClip audio;

    public string Id => id;

    public AudioClip Audio { get => audio; private set => audio = value; }
}
