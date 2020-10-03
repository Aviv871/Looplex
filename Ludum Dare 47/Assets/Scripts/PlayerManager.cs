using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 2f;
    [SerializeField] private InteractionsManager interactionsManager = null;

    // Start is called before the first frame update
    private void Start()
    {

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
                interactionsManager.ExecuteInteraction(intractable.name, distance);
            }
        }
    }
}
