using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer = null;
    [SerializeField] private Slider voulmeSlider = null;

    public void quit()
    {
        Application.Quit();
    }

    public void play()
    {
        Fader.faderInstance.FadeTo("Main");
    }

    public void volumeSet()
    {
        masterMixer.SetFloat("MainVoulme", Mathf.Log(voulmeSlider.value) * 20);
        StaticManager.volume = voulmeSlider.value;
    }
}
