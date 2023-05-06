using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource backgroundMusic;
    float vol;

    void Start()
    { 
        // Set the slider's initial value to the background music's current volume.
        volumeSlider.value = backgroundMusic.volume;
    }

    // Update the background music's volume based on the slider's new value.
    private void Update()
    {
        vol = volumeSlider.value;
        backgroundMusic.volume = vol;
    }

    public void OnVolumeSliderChanged(float newValue)
    {
        print(newValue);

        backgroundMusic.volume = newValue;
    }
}