using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicToggleScript : MonoBehaviour
{
    public AudioSource music;

    public void ToggleMusic()
    {
        music.enabled = !music.enabled;
    }
}
