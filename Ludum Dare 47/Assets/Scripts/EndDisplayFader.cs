using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDisplayFader : MonoBehaviour
{
    [SerializeField] private Image[] images = null;
    [SerializeField] private Text[] texts = null;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float a = 0f;
        while (a < 1f)
        {
            foreach (Image image in images)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, a);
            }
            foreach (Text text in texts)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, a);
            }

            a += Time.deltaTime;
            yield return 0;
        }
    }
}
