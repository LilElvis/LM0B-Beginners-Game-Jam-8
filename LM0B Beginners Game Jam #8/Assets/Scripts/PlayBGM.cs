using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGM : MonoBehaviour
{
    AudioSource audioSourceRef = null;
    public AudioClip bgmIntro = null;
    public AudioClip bgmLoop = null;

    WaitForSeconds introTime;

    void Awake()
    {
        audioSourceRef = GetComponent<AudioSource>();
    }

    void Start()
    {
        introTime = new WaitForSeconds(bgmIntro.length);
        StartCoroutine(playBGM());
    }

    IEnumerator playBGM()
    {
        audioSourceRef.PlayOneShot(bgmIntro);
        yield return introTime;
        audioSourceRef.Play();
        audioSourceRef.loop = true;

        yield break;
    }

}
