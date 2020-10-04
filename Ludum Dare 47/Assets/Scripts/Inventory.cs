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
    [SerializeField] private Sprite BlackBookSprite = null;
    [SerializeField] private Sprite greenBookSprite = null;
    [SerializeField] private Sprite stickSprite = null;

    public enum InventoryItem
    {
        NULL,
        KEY,
        STICK,
        BLUE_BOOK,
        BLACK_BOOK,
        GREEN_BOOK
    }

    public void AddItem(InventoryItem item)
    {
        Debug.Log(item.ToString() + " added to the inventory");
        currentInventory.Add(item);
        UpdateIventoryGUI();
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
            inventorySlots[i].GetComponentInChildren<Image>().enabled = false;
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
            case (InventoryItem.BLACK_BOOK):
                return BlackBookSprite;
            case (InventoryItem.BLUE_BOOK):
                return blueBookSprite;
            case (InventoryItem.GREEN_BOOK):
                return greenBookSprite;
            default:
                return null;
        }
    }
}
