using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer audiomixer;
    public Slider masterVolumeSlider;

    private void Awake()
    {
        StartCoroutine(GetAudioAsset());
        masterVolumeSlider = FindObjectOfType<Slider>();
    }

    public void MVSliderController()
    {

        audiomixer.SetFloat("BackgroundMusic", masterVolumeSlider.value);

    }

    IEnumerator GetAudioAsset() {

        ResourceRequest resourceAuioMixer = Resources.LoadAsync<AudioMixer>("Audio/AudioMixer");
        audiomixer = resourceAuioMixer.asset as AudioMixer;
        yield return 0;
    }
}
