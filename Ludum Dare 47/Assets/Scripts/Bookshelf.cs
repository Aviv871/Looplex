using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{
    [SerializeField] private GameObject blueBook = null;
    [SerializeField] private GameObject brownBook = null;
    [SerializeField] private GameObject redBook = null;

    private bool hasBlue = false;
    private bool hasBrown = false;
    private bool hasRed = false;

    public void AddBook(Inventory.InventoryItem book)
    {
        // TOOD: play sound
        switch (book)
        {
            case Inventory.InventoryItem.RED_BOOK:
                redBook.SetActive(true);
                hasRed = true;
                break;
            case Inventory.InventoryItem.BLUE_BOOK:
                blueBook.SetActive(true);
                hasBlue = true;
                break;
            case Inventory.InventoryItem.BROWN_BOOK:
                brownBook.SetActive(true);
                hasBrown = true;
                break;
        }
    }

    public bool IsFull()
    {
        return hasBrown && hasBlue && hasRed;
    }
}
