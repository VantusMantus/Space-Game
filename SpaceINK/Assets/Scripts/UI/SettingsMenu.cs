﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField]
    private Toggle toggleVFX;

    [SerializeField]
    private Toggle toggleMusic;

    // Start is called before the first frame update
    void Awake()
    {
        Invoke("SetDefaultToogle", 0.1f);
    }

    public void SetDefaultToogle()
    {
        if (!PlayerPrefs.HasKey("soundVFX"))
        {
            PlayerPrefs.SetInt("soundVFX", 1);
            toggleVFX.isOn = true;
            FindObjectOfType<AudioManager>().audioVFX = true;
            PlayerPrefs.Save();
        }
        // 2
        else
        {
            if (PlayerPrefs.GetInt("soundVFX") == 0)
            {
                toggleVFX.isOn = false;
                FindObjectOfType<AudioManager>().audioVFX = false;
            }
            else
            {
                toggleVFX.isOn = true;
                FindObjectOfType<AudioManager>().audioVFX = true;
            }
        }
        ////////////////////////////////////////////////////////////////
        if (!PlayerPrefs.HasKey("musicVFX"))
        {
            PlayerPrefs.SetInt("musicVFX", 1);
            toggleMusic.isOn = true;
            FindObjectOfType<AudioManager>().PlayMusic("MenuTheme");
            PlayerPrefs.Save();
        }
        // 2
        else
        {
            if (PlayerPrefs.GetInt("musicVFX") == 0)
            {
                toggleMusic.isOn = false;
                FindObjectOfType<AudioManager>().Stop("MenuTheme");
                Debug.Log("Stop Music 1");
            }
            else
            {
                toggleMusic.isOn = true;
                FindObjectOfType<AudioManager>().PlayMusic("MenuTheme");
            }
        }
    }
    public void ToggleVFX()
    {
        if (toggleVFX.isOn)
        {
            PlayerPrefs.SetInt("soundVFX", 1);
            FindObjectOfType<AudioManager>().audioVFX = true;
        }
        else
        {
            PlayerPrefs.SetInt("soundVFX", 0);
            FindObjectOfType<AudioManager>().audioVFX = false;
        }
        PlayerPrefs.Save();
    }


    public void ToggleMusic() 
    {
        if (toggleMusic.isOn)
        {
            PlayerPrefs.SetInt("musicVFX", 1);
            FindObjectOfType<AudioManager>().PlayMusic("MenuTheme");
        }
        else
        {
            PlayerPrefs.SetInt("musicVFX", 0);
            FindObjectOfType<AudioManager>().Stop("MenuTheme");
            Debug.Log("Stop Music 2");
        }
        PlayerPrefs.Save();
    }
}
