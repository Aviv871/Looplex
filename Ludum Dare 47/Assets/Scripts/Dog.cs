using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private GameObject clueBelowDog = null;

    private bool isHappy = false;
    private Vector3 wantedPosition;
    private Vector3 velocity = Vector3.zero;
    
    [SerializeField] private float moveSpeed = 0.3F;
    [SerializeField] private Vector3 locationAfterStick = Vector3.zero;

    public void FetchStick()
    {
        // TODO: sound here
        isHappy = true;
        clueBelowDog.SetActive(true);
        wantedPosition = locationAfterStick;
    }

    public bool IsHappy()
    {
        return isHappy;
    }

    private void Start()
    {
        wantedPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != wantedPosition)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, wantedPosition, ref velocity, moveSpeed);
        }
    }
}
