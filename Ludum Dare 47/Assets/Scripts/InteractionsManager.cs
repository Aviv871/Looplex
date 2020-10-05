using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionsManager : MonoBehaviour
{
    [SerializeField] private GameObject endUIObject = null;
    [SerializeField] private GameObject player = null;
    [SerializeField] private Door leversDoor = null;
    [SerializeField] private Inventory playerInventory = null;
    [SerializeField] private ClueDisplay clueDisplay = null;
    [SerializeField] private Core coreObject = null;
    [SerializeField] private Text endULoopCount = null;
    [SerializeField] private AudioSource leverSound = null;
    [SerializeField] private AudioSource pickupSound = null;
    [SerializeField] private AudioSource tableSound = null;
    [SerializeField] private AudioSource coreOffSound = null;
    [SerializeField] private AudioSource mainMusic = null;

    private bool yellowLeverState = false;
    private bool whiteLeverState = false;
    private bool pinkLeverState = false;
    private bool emptyLeverState = false;

    private int digitBoard1Value = 0;
    private int digitBoard2Value = 0;
    private int digitBoard3Value = 0;

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

            case "DigitBoard1":
                digitBoard1Value = interactionGameObject.GetComponent<DigitBoard>().IncreaseValue();
                HandleDigitBoardACtion();
                break;

            case "DigitBoard2":
                digitBoard2Value = interactionGameObject.GetComponent<DigitBoard>().IncreaseValue();
                HandleDigitBoardACtion();
                break;

            case "DigitBoard3":
                digitBoard3Value = interactionGameObject.GetComponent<DigitBoard>().IncreaseValue();
                HandleDigitBoardACtion();
                break;
        }
    }

    private void HandleLeverSwitch(GameObject lever)
    {
        lever.transform.localScale = new Vector3(lever.transform.localScale.x * -1, lever.transform.localScale.y, lever.transform.localScale.z);
        leverSound.Play();
        CheckLeversSolution();
    }

    private void HandleDigitBoardACtion()
    {
        leverSound.Play();
        CheckDigitsSolution();
    }

    private void CheckDigitsSolution()
    {
        if (digitBoard1Value == 3 && digitBoard2Value == 8 && digitBoard3Value == 6)
        {
            Debug.Log("Digits in right config!");
            TimeManager.timeManagerInstance.SetActive(false);
            mainMusic.Stop();
            player.GetComponent<PlayerManager>().enabled = false;
            coreOffSound.Play();
            coreObject.SetCoreOff();
            StartCoroutine(ShowEndUI());
        }
    }

    private void CheckLeversSolution()
    {
        if (yellowLeverState && !pinkLeverState && whiteLeverState && emptyLeverState)
        {
            Debug.Log("Levers in right config!");
            leversDoor.Open();
        }
    }

    private IEnumerator ShowEndUI()
    {
        yield return new WaitForSeconds(5f);
        player.SetActive(false);
        endUIObject.SetActive(true);
        endULoopCount.text = endULoopCount.text + StaticManager.loopsCount.ToString();
    }
}
