using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public float fadeInTime;
    public float fadeOutTime;

    private AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music = gameObject.GetComponent<AudioSource>();
        music.volume = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeIn()
    {
        music = gameObject.GetComponent<AudioSource>();
        music.volume = 1f;
        float startVolume = music.volume;
        music.volume = 0;
        music.Play();
        while (music.volume < startVolume)
        {
            music.volume += startVolume * Time.deltaTime / fadeInTime;
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        float startVolume = music.volume;

        while (music.volume > 0)
        {
            music.volume -= startVolume * Time.deltaTime / fadeOutTime;
            yield return null;
        }
        music.Stop();
        music.volume = startVolume;
        
    }
}
