using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public GameObject BMG;
    public AudioSource Finish;
    public AudioSource Hurt;
    public AudioSource Death;
    public AudioSource collectedItem;
    public AudioSource Clicked;
    public AudioSource Jump;
    public AudioSource Checkpoint;

    private void Awake()
    {
        Instance = this;
        Finish = GetComponent<AudioSource>();
    }
    public void PlayBMGSound()
    {
        BMG.GetComponent<AudioSource>().Play();
    }

    public void StopBMGSound()
    {
        BMG.GetComponent<AudioSource>().Stop();
    }

    public void PlayFinishSound()
    {     
        Finish.Play();
    }

    public void PlayHurtSound()
    {
        Hurt.Play();
    }

    public void PlayDeathSound()
    {
        Death.Play();
    }

    public void PlayCollectedSound()
    {
        collectedItem.Play();
    }

    public void PlayMouseClickedSound()
    {
        Clicked.Play();
    }

    public void PlayJumpSound()
    {
        Jump.Play();
    }

    public void PlayCheckpointSound()
    {
        Checkpoint.Play();
    }
}
