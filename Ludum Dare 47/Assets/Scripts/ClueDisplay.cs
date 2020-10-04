using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueDisplay : MonoBehaviour
{
    [SerializeField] private GameObject clueDisplay = null;
    [SerializeField] private Image clueContainer = null;

    [Header("Clues Assets")]
    [SerializeField] private Sprite flowerLeverSoultion = null;
    [SerializeField] private Sprite whereToStand = null;
    [SerializeField] private Sprite barkStick = null;
    [SerializeField] private Sprite orderOfDigits = null;
    [SerializeField] private Sprite booksCloseup = null;

    public enum ClueDisplayType
    {
        FLOWER_LEVER_SOULTION,
        WHERE_TO_STAND,
        BARK_STICK,
        ORDER_OF_DIGITS,
        BOOKS_CLOSEUP,
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
            case ClueDisplayType.BARK_STICK:
                clueContainer.sprite = barkStick;
                break;
            case ClueDisplayType.ORDER_OF_DIGITS:
                clueContainer.sprite = orderOfDigits;
                break;
            case ClueDisplayType.BOOKS_CLOSEUP:
                clueContainer.sprite = booksCloseup;
                break;
        }
        clueDisplay.SetActive(true);
    }
}
