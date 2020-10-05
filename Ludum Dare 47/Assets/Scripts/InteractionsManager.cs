using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    [SerializeField] private Door leversDoor = null;
    [SerializeField] private Inventory playerInventory = null;
    [SerializeField] private ClueDisplay clueDisplay = null;
    [SerializeField] private AudioSource leverSound = null;
    [SerializeField] private AudioSource pickupSound = null;
    [SerializeField] private AudioSource tableSound = null;

    private bool yellowLeverState = false;
    private bool whiteLeverState = false;
    private bool pinkLeverState = false;
    private bool emptyLeverState = false;

    public void ExecuteInteraction(GameObject interactionGameObject, float distanceTo)
    {
        switch (interactionGameObject.name)
        {
            case "GardenTable":
                Debug.Log("Leave the table alone!");
                tableSound.Play();
                clueDisplay.Show(ClueDisplay.ClueDisplayType.BARK_STICK);
                break;

            case "HallTable":
                Debug.Log("Leave the table alone!");
                tableSound.Play();
                clueDisplay.Show(ClueDisplay.ClueDisplayType.WHERE_TO_STAND);
                break;

            case "ClueBelowDog":
                clueDisplay.Show(ClueDisplay.ClueDisplayType.ORDER_OF_DIGITS);
                break;

            case "Key":
                playerInventory.AddItem(Inventory.InventoryItem.KEY);
                Destroy(interactionGameObject);
                pickupSound.Play();
                break;

            case "Chest":
                Chest chestComp = interactionGameObject.GetComponent<Chest>();
                if (chestComp.IsOpen())
                {
                    clueDisplay.Show(ClueDisplay.ClueDisplayType.FLOWER_LEVER_SOULTION);
                }
                else
                {
                    if (playerInventory.DoesExist(Inventory.InventoryItem.KEY))
                    {
                        chestComp.Open();
                    }
                }
                break;

            case "LeverYellow":
                yellowLeverState = !yellowLeverState;
                HandleLeverSwitch(interactionGameObject);
                break;

            case "LeverWhite":
                whiteLeverState = !whiteLeverState;
                HandleLeverSwitch(interactionGameObject);
                break;

            case "LeverPink":
                pinkLeverState = !pinkLeverState;
                HandleLeverSwitch(interactionGameObject);
                break;

            case "LeverEmpty":
                emptyLeverState = !emptyLeverState;
                HandleLeverSwitch(interactionGameObject);
                break;

            case "Stick":
                playerInventory.AddItem(Inventory.InventoryItem.STICK);
                Destroy(interactionGameObject);
                pickupSound.Play();
                break;

            case "Dog":
                Dog dogComp = interactionGameObject.GetComponent<Dog>();
                if (!dogComp.IsHappy() && dogComp.CanReceiveStick())
                {
                    if (playerInventory.DoesExist(Inventory.InventoryItem.STICK))
                    {
                        playerInventory.RemoveItem(Inventory.InventoryItem.STICK);
                        dogComp.FetchStick();
                    }
                }
                break;

            case "BrownBook":
                playerInventory.AddItem(Inventory.InventoryItem.BROWN_BOOK);
                Destroy(interactionGameObject);
                pickupSound.Play();
                break;

            case "BlueBook":
                playerInventory.AddItem(Inventory.InventoryItem.BLUE_BOOK);
                Destroy(interactionGameObject);
                pickupSound.Play();
                break;

            case "RedBook":
                playerInventory.AddItem(Inventory.InventoryItem.RED_BOOK);
                Destroy(interactionGameObject);
                pickupSound.Play();
                break;

            case "Bookshelf":
                Bookshelf bookshelfComp = interactionGameObject.GetComponent<Bookshelf>();
                if (bookshelfComp.IsFull())
                {
                    Debug.Log("Bookshelf full!");
                    tableSound.Play();
                    clueDisplay.Show(ClueDisplay.ClueDisplayType.BOOKS_CLOSEUP);
                }
                else
                {
                    Inventory.InventoryItem book = playerInventory.GetBook();
                    if (book != Inventory.InventoryItem.NULL)
                    {
                        playerInventory.RemoveItem(book);
                        bookshelfComp.AddBook(book);
                    }
                }
                break;
        }
    }

    private void HandleLeverSwitch(GameObject lever)
    {
        Debug.Log(lever.name);
        lever.transform.localScale = new Vector3(lever.transform.localScale.x * -1, lever.transform.localScale.y, lever.transform.localScale.z);
        leverSound.Play();
        CheckLeversSolution();
    }

    private void CheckLeversSolution()
    {
        if (yellowLeverState && pinkLeverState && !whiteLeverState && emptyLeverState)
        {
            Debug.Log("Levers in right config!");
            leversDoor.Open();
        }
    }
}
