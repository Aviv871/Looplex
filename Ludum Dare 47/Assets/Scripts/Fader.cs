using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    [SerializeField] private Image[] images = null;
    [SerializeField] private AudioSource music = null;
    public static bool Fading = true;

    public static Fader faderInstance;

    private void Awake()
    {
        if (faderInstance != null) Debug.LogError("More than 1 fader in scene! Use only one");
        faderInstance = this;
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    private IEnumerator FadeOut(string scene)
    {
        foreach (Image image in images)
        {
            image.enabled = true;
        }
        if (music != null) music.enabled = false;

        float a = 0f;
        while (a < 1f)
        {
            foreach (Image image in images)
            {
                image.color = new Color(0f, 0f, 0f, a);
            }

            a += Time.deltaTime;
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    private IEnumerator FadeIn()
    {
        foreach (Image image in images)
        {
            image.enabled = true;
        }

        float a = 1f;

        while (a > 0f)
        {
            foreach (Image image in images)
            {
                image.color = new Color(0f, 0f, 0f, a);
            }
            a -= Time.unscaledDeltaTime;
            yield return 0;
        }
        Fading = false;

        foreach (Image image in images)
        {
            image.enabled = false;
        }
    }
}
