using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Jumping")]
    [SerializeField] AudioClip JumpingClip;
    [SerializeField] [Range(0f, 1f)] float JumpingVolume = 1f;

    [Header("Hitted")]
    [SerializeField] AudioClip HittedClip;
    [SerializeField] [Range(0f, 1f)] float HittedVolume = 1f;

    [Header("Explosion")]
    [SerializeField] AudioClip ExplosionClip;
    [SerializeField] [Range(0f, 1f)] float ExplosionVolume = 1f;
    [Header("Dig")]
    [SerializeField] AudioClip DigClip;
    [SerializeField] [Range(0f, 1f)] float DigVolume = 1f;
    [Header("Alert")]
    [SerializeField] AudioClip AlertClip;
    [SerializeField] [Range(0f, 1f)] float AlertVolume = 1f;

    static AudioPlayer instance;

    public void ResetOurScenePersist()
    {
        Destroy(gameObject);
    }

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayJumpingClip()
    {
        PlayClip(JumpingClip, JumpingVolume);
    }

    public void PlayHittedClip()
    {
        PlayClip(HittedClip, HittedVolume);
    }
    public void PlayExplosionClip()
    {
        PlayClip(ExplosionClip, ExplosionVolume);
    }

    public void PlayDigClip()
    {
        PlayClip(DigClip, DigVolume);
    }
    public void PlaAlertClip()
    {
        PlayClip(AlertClip, AlertVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
