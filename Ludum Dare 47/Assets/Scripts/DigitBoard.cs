using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitBoard : MonoBehaviour
{
    [SerializeField] private Text textDisplay = null;

    private int currntDigit = 0;

    public int IncreaseValue()
    {
        currntDigit++;
        if (currntDigit == 10)
        {
            currntDigit = 0;
        }
        UpdateDisplay();
        return currntDigit;
    }

    private void UpdateDisplay()
    {
        textDisplay.text = currntDigit.ToString();
    }
}
