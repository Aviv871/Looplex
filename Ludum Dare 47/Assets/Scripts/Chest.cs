using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Sprite openSprite = null;

    private bool isOpen = false;

    public void Open()
    {
        // TODO: chest sound here
        GetComponent<SpriteRenderer>().sprite = openSprite;
        isOpen = true;
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
