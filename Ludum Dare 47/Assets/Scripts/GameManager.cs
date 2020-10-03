using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float loopLength = 180f;

    private int loopsCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        TimeManager.timeManagerInstance.RegisterTimeEvent(loopLength, endOfLoopEvent);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void endOfLoopEvent(float timeDelta)
    {
        Debug.Log("End of loop");
        loopsCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
