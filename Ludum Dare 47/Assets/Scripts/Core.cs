using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    [Header("Fading")]
    [SerializeField] private float fadeTime = 2f;

    private SpriteRenderer spriteRenderer;
    private Color offCoreColor = new Color(1f, 1f, 1f, 0f);
    private bool isOff = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isOff && spriteRenderer.color.a != 0)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, offCoreColor, fadeTime);
        }
    }

    public void SetCoreOff()
    {
        isOff = true;
    }
}
