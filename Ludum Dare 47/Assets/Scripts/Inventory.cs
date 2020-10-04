using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> currentInventory = new List<InventoryItem>();
    [SerializeField] private GameObject[] inventorySlots = null;

    [SerializeField] private Sprite keySprite = null;
    [SerializeField] private Sprite blueBookSprite = null;
    [SerializeField] private Sprite brownBookSprite = null;
    [SerializeField] private Sprite redBookSprite = null;
    [SerializeField] private Sprite stickSprite = null;

    public enum InventoryItem
    {
        NULL,
        KEY,
        STICK,
        BLUE_BOOK,
        BROWN_BOOK,
        RED_BOOK
    }

    public void AddItem(InventoryItem item)
    {
        if (!DoesExist(item))
        {
            Debug.Log(item.ToString() + " added to the inventory");
            currentInventory.Add(item);
            UpdateIventoryGUI();
        }
        else
        {
            Debug.Log("Item already in inventory");
        }
    }

    public void RemoveItem(InventoryItem item)
    {
        Debug.Log(item.ToString() + " removed from the inventory");
        currentInventory.Remove(item);
        UpdateIventoryGUI();
    }

    public bool DoesExist(InventoryItem item)
    {
        InventoryItem result = currentInventory.Find(x => x == item);
        return result != InventoryItem.NULL;
    }

    public InventoryItem GetBook()
    {
        if (DoesExist(InventoryItem.RED_BOOK))
        {
            return InventoryItem.RED_BOOK;
        }
        else if (DoesExist(InventoryItem.BROWN_BOOK))
        {
            return InventoryItem.BROWN_BOOK;
        }
        else if (DoesExist(InventoryItem.BLUE_BOOK))
        {
            return InventoryItem.BLUE_BOOK;
        }
        return InventoryItem.NULL;
    }

    private void UpdateIventoryGUI()
    {
        for (int i = 0; i < currentInventory.Count; i++)
        {
            if (i >= inventorySlots.Length)
            {
                break;
            }

            inventorySlots[i].GetComponent<Image>().enabled = true;
            inventorySlots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
            inventorySlots[i].transform.GetChild(0).GetComponent<Image>().sprite = GetMatchingSprite(currentInventory[i]);
        }

        // Empty slots 
        for (int i = currentInventory.Count; i < inventorySlots.Length; i++)
        {
            if (i >= inventorySlots.Length)
            {
                break;
            }

            inventorySlots[i].GetComponent<Image>().enabled = false;
            inventorySlots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
    }

    private Sprite GetMatchingSprite(InventoryItem item)
    {
        switch (item)
        {
            case (InventoryItem.KEY):
                return keySprite;
            case (InventoryItem.STICK):
                return stickSprite;
            case (InventoryItem.RED_BOOK):
                return redBookSprite;
            case (InventoryItem.BLUE_BOOK):
                return blueBookSprite;
            case (InventoryItem.BROWN_BOOK):
                return brownBookSprite;
            default:
                return null;
        }
    }
}
