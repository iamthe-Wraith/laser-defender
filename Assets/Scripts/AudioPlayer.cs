using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f,1f)] float damageVolume = 1f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
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

    private void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(
                clip, 
                Camera.main.transform.position,
                volume
            );
        }
    }

    public void PlayExplosionClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }
}
