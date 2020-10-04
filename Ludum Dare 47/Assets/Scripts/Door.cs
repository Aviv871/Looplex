using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Sprite openSprite = null;
    [SerializeField] private AudioSource doorOpenSound = null;

    private bool isOpen = false;

    public void Open()
    {
        doorOpenSound.Play();
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = openSprite;
        isOpen = true;
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
