using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
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
                // TOOD: Display clue GUI
                break;
            case "HallTable":
                Debug.Log("Leave the table alone!");
                // TOOD: Display clue GUI
                break;
            case "Key":
                Debug.Log("Very nice key!");
                // TODO: pick up to inventory
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
        }
    }

    private void HandleLeverSwitch(GameObject lever)
    {
        Debug.Log(lever.name);
        lever.transform.localScale = new Vector3(lever.transform.localScale.x * -1, lever.transform.localScale.y, lever.transform.localScale.z);
        // TODO: lever sound here
        CheckLeversSolution();
    }

    private void CheckLeversSolution()
    {
        if (yellowLeverState && pinkLeverState && !whiteLeverState && emptyLeverState)
        {
            Debug.Log("Levers in right config!");
        }
    }
}
