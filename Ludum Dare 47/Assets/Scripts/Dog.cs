using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private GameObject clueBelowDog = null;
    [SerializeField] private AudioSource dogBarkingSound = null;
    [SerializeField] private AudioSource dogHappySound = null;
    [SerializeField] private float breakingTime = 4f;
    [SerializeField] private float endOfStickWindowTime = 5f;

    private bool isHappy = false;
    private bool canReceiveStick = false;
    private Vector3 wantedPosition;
    private Vector3 velocity = Vector3.zero;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 0.3F;
    [SerializeField] private Vector3 locationAfterStick = Vector3.zero;

    public void FetchStick()
    {
        dogHappySound.Play();
        isHappy = true;
        clueBelowDog.SetActive(true);
        wantedPosition = locationAfterStick;
        GetComponent<Animator>().SetTrigger("DogStickTrigger");
    }

    public bool CanReceiveStick()
    {
        return canReceiveStick;
    }

    public bool IsHappy()
    {
        return isHappy;
    }

    private void Start()
    {
        TimeManager.timeManagerInstance.RegisterTimeEvent(breakingTime, Bark);
        TimeManager.timeManagerInstance.RegisterTimeEvent(endOfStickWindowTime, EndOfStickWindow);
        wantedPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != wantedPosition)
        {
            transform.localPosition = Vector3.SmoothDamp(transform.localPosition, wantedPosition, ref velocity, moveSpeed);
        }
    }

    private void Bark(float timeDelta)
    {
        dogBarkingSound.Play();
        canReceiveStick = true;
    }

    private void EndOfStickWindow(float timeDelta)
    {
        canReceiveStick = false;
    }
}
