using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] private InteractionsManager interactionsManager = null;

    private void playerAfter3SecEvent(float timeDelta)
    {
        Debug.Log("Player says hello! Delta: " + timeDelta);
    }

    // Start is called before the first frame update
    private void Start()
    {
        TimeManager.timeManagerInstance.RegisterTimeEvent(3f, playerAfter3SecEvent);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleIntractables();
        }
    }

    private void HandleIntractables()
    {
        GameObject[] intractables = GameObject.FindGameObjectsWithTag("Intractable");
        foreach (var intractable in intractables)
        {
            float distance = Vector2.Distance(gameObject.transform.position, intractable.transform.position);
            if (distance < interactionDistance)
            {
                Debug.Log("Player intraction with " + intractable.name);
                interactionsManager.ExecuteInteraction(intractable.name, distance);

                // If for some reason there are 2 very close intractables we want to handle only one
                break;
            }
        }
    }
}
