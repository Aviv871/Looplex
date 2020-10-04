using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueDisplay : MonoBehaviour
{
    [SerializeField] private GameObject clueDisplay = null;
    [SerializeField] private Image clueContainer = null;

    [SerializeField] private Sprite flowerLeverSoultion = null;
    [SerializeField] private Sprite whereToStand = null;
    [SerializeField] private Sprite orderOfDigits = null;

    public enum ClueDisplayType
    {
        FLOWER_LEVER_SOULTION,
        WHERE_TO_STAND,
        ORDER_OF_DIGITS
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            clueDisplay.SetActive(false);
        }
    }

    public void Show(ClueDisplayType clueToDisplay)
    {
        switch (clueToDisplay)
        {
            case ClueDisplayType.FLOWER_LEVER_SOULTION:
                clueContainer.sprite = flowerLeverSoultion;
                break;
            case ClueDisplayType.WHERE_TO_STAND:
                clueContainer.sprite = whereToStand;
                break;
            case ClueDisplayType.ORDER_OF_DIGITS:
                clueContainer.sprite = orderOfDigits;
                break;
        }
        clueDisplay.SetActive(true);
    }
}
