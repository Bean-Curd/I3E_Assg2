/*
 * Author: Ashley Goh Yu Ting
 * Date: 02/07/2023
 * Description: I3E/STLD Assignment 2 - Volume Settings
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //For audio
using UnityEngine.UI; //For the UI 
using TMPro; //For TextMeshPro

public class VolumeSettings : MonoBehaviour
{
    /// <summary>
    /// AudioMixer
    /// </summary>
    public AudioMixer myMixer;
    /// <summary>
    /// Slider for volume
    /// </summary>
    public Slider volumeSlider;
    /// <summary>
    /// Slider for music
    /// </summary>
    public Slider musicSlider;
    /// <summary>
    /// Slider for v
    /// </summary>
    public Slider sfxSlider;

    /// <summary>
    /// So it can be accessed by other scripts
    /// </summary>
    public static VolumeSettings instance;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Set volume
    /// </summary>
    public void SetVolume()
    {
        float volume = volumeSlider.value;
        myMixer.SetFloat("Volume", Mathf.Log10(volume) * 20); //Convert linear slider to log audio mixer
    }
    /// <summary>
    /// Set music
    /// </summary>
    public void SetMusic()
    {
        float music = musicSlider.value;
        myMixer.SetFloat("Music", Mathf.Log10(music) * 20);
    }
    /// <summary>
    /// Set SFX
    /// </summary>
    public void SetSFX()
    {
        float sfx = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(sfx) * 20);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetVolume();
        SetMusic();
        SetSFX();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
