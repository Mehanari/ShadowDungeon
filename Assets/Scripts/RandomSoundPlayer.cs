using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _clips;
    [SerializeField] private AudioSource _source;

    public void PlayRandomSound()
    {
        int index = Random.Range(0, _clips.Count);
        var clip = _clips[index];
        _source.clip = clip;
        _source.Play();
    }
}
