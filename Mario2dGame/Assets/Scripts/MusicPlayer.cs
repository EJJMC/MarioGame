using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicPlayer : MonoBehaviour
{

    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject efxOn;
    public GameObject efxOff;

    public AudioSource BGMAudioSource;
    private float bgmAudioVolume = 1f;

    public AudioSource [] EFXAudioSource;
    private float efxAudioVolume = 1f;

    private bool isBGMOn;
    private bool isEFXOn;

    // Start is called before the first frame update
    void Start()
    {
        float bgmVolPresPrefs = PlayerPrefs.GetFloat("gamebgm");
        float efxVolPresPrefs = PlayerPrefs.GetFloat("gameefx");
        bool bgmOnPresPrefs = (PlayerPrefs.GetInt("bgmon") != 0);
        bool efxOnPresPrefs = (PlayerPrefs.GetInt("efxon") != 0);

        if (bgmVolPresPrefs >= 0f && bgmVolPresPrefs <= 1f)
        {
            bgmAudioVolume = bgmVolPresPrefs;
        }

        if (efxVolPresPrefs >= 0f && efxVolPresPrefs <= 1f)
        {
            efxAudioVolume = efxVolPresPrefs;
        }

        if (bgmOnPresPrefs == true)
        {
            bgmToggleONHandler();
            bgmAudioVolume = bgmVolPresPrefs;
            //isBGMOn = bgmOnPresPrefs;
        } else
        {
            bgmToggleOFFHandler();
        }

        if (efxOnPresPrefs == true)
        {
            efxToggleONHandler();
            efxAudioVolume = efxVolPresPrefs;
            //isEFXOn = efxOnPresPrefs;
        } else
        {
            efxToggleOFFHandler();
        }
    }

    // Update is called once per frame
    void Update()
    {
        BGMAudioSource.volume = bgmAudioVolume;
        EFXAudioSource[0].volume = efxAudioVolume;

        if (isEFXOn)
        {
            efxOn.SetActive(false);
            efxOff.SetActive(true);
        }
        else if (!isEFXOn)
        {
            efxOn.SetActive(true);
            efxOff.SetActive(false);
        }

        if (isBGMOn)
        {   
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        else if (!isBGMOn)
        {
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
    }

    // This function is used to handle the music volume slider
    public void bgmVolumeHandler(float volume)
    {
        bgmAudioVolume = volume;
        PlayerPrefs.SetFloat("gamebgm", volume);
    }

    // This function is used to handle the efx volume slider
    public void efxVolumeHandler(float volume)
    {
        efxAudioVolume = volume;
        PlayerPrefs.SetFloat("gameefx", volume);
    }

    // This function is used to handle the music on/off toggle
    public void bgmToggleONHandler()
    {
        BGMAudioSource.Play();
        isBGMOn = true;
        PlayerPrefs.SetInt("bgmon", 1);
    }

    public void bgmToggleOFFHandler()
    {
        BGMAudioSource.Pause();
        isBGMOn = false;
        PlayerPrefs.SetInt("bgmon", 0);
    }

    // This function is used to handle the efx on/off toggle
    public void efxToggleONHandler()
    {
        EFXAudioSource[0].Play();
        isEFXOn = true;
        PlayerPrefs.SetInt("efxon", 1);
    }

    public void efxToggleOFFHandler()
    {
        EFXAudioSource[0].Stop();
        isEFXOn = false;
        PlayerPrefs.SetInt("efxon", 0);
    }
}
