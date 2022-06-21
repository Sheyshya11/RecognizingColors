using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListAudio : MonoBehaviour
{
    [SerializeField] List<AudioClip> gameSounds = new List<AudioClip>();
    AudioSource audioSource;
    [SerializeField] int orderList;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        orderList = 1;

    }

    public void ClickButton()
    {
        audioSource.clip = gameSounds[0];
        audioSource.Play();
    }
    public void UnClickButton()
    {
        audioSource.clip = gameSounds[1];
        audioSource.Play();
    }

    public void WaterSlash()
    {
        audioSource.clip = gameSounds[2];
        audioSource.Play();
    }

    public void WaterSlashReEntry()
    {
        audioSource.clip = gameSounds[3];
        audioSource.Play();
    }

    public void ResetOrder()
    {
        orderList = 1;
    }

    public void PlayOrder()
    {
        audioSource.clip = gameSounds[orderList];
        audioSource.Play();
        if (orderList <= gameSounds.Count)
        {
            orderList++;
        }
        else
        {
            ResetOrder();
        }

    }
}


