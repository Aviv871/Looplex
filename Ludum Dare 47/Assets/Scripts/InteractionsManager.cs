using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExecuteInteraction(GameObject gameObject, float distanceTo)
    {
        switch (gameObject.name)
        {
            case "Table":
                Debug.Log("Leave the table alone!");
                break;
            case "Key":
                Debug.Log("Very nice key!");
                break;
            case "c":
                break;
        }
    }
}
