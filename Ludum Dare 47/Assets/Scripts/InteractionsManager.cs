using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    [SerializeField] private Door leversDoor = null;
    [SerializeField] private Inventory playerInventory = null;
    [SerializeField] private AudioSource leverSound = null;
    [SerializeField] private AudioSource pickupSound = null;
    [SerializeField] private AudioSource tableSound = null;

    private bool yellowLeverState = false;
    private bool whiteLeverState = false;
    private bool pinkLeverState = false;
    private bool emptyLeverState = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExecuteInteraction(GameObject interactionGameObject, float distanceTo)
    {
        switch (interactionGameObject.name)
        {
            case "GardenTable":
                Debug.Log("Leave the table alone!");
                tableSound.Play();
                // TODO: Display clue GUI
                break;

            case "HallTable":
                Debug.Log("Leave the table alone!");
                tableSound.Play();
                // TODO: Display clue GUI
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
                    // TODO: Display clue GUI
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
                if (!dogComp.IsHappy())
                {
                    if (playerInventory.DoesExist(Inventory.InventoryItem.STICK))
                    {
                        dogComp.FetchStick();
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
