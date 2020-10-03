using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float screenCaptureInterval = 1f;

    public static TimeManager timeManagerInstance;

    private float timeSinceLastCapture = 0f;
    private int capturesCount = 0;

    // The action to be executated at the event, takes the delta since the wanted event time to now
    public delegate void TimeEventFunc(float timeDelta);
    private Dictionary<float, List<TimeEventFunc>> timeEvents = new Dictionary<float, List<TimeEventFunc>>();

    private void Awake()
    {
        if (timeManagerInstance != null) Debug.LogError("More than 1 timeManagerInstance in scene! Use only one");
        timeManagerInstance = this;
        timeEvents.Clear();
    }

    private void Start()
    {
        // This make sure there will be a snapshot on the very beginning
        timeSinceLastCapture = screenCaptureInterval + 1;

        DirectoryInfo di = new DirectoryInfo(Application.temporaryCachePath);
        foreach (FileInfo file in di.GetFiles("capture*.png"))
        {
            file.Delete();
        }
    }

    public void RegisterTimeEvent(float time, TimeEventFunc action)
    {
        if (timeEvents.ContainsKey(time))
        {
            timeEvents[time].Add(action);
        }
        else
        {
            List<TimeEventFunc> newList = new List<TimeEventFunc> { action };
            timeEvents.Add(time, newList);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        HandleTimeEvents();
        HandleScreenCaptures();
    }

    private void HandleScreenCaptures()
    {
        timeSinceLastCapture += Time.deltaTime;
        if (timeSinceLastCapture > screenCaptureInterval)
        {
            timeSinceLastCapture = 0f;
            capturesCount++;
            ScreenCapture.CaptureScreenshot(Path.Combine(Application.temporaryCachePath, "capture" + capturesCount.ToString() + ".png"));
        }
    }

    private void HandleTimeEvents()
    {
        List<float> keysToRemove = new List<float>();

        foreach (var item in timeEvents)
        {
            if (item.Key < Time.timeSinceLevelLoad)
            {
                keysToRemove.Add(item.Key);
                foreach (var action in item.Value)
                {
                    Debug.Log("Time event triggered, current time: " + Time.timeSinceLevelLoad);
                    action(Time.timeSinceLevelLoad - item.Key);
                }
            }
        }

        foreach (var keyToRemove in keysToRemove)
        {
            timeEvents.Remove(keyToRemove);
        }
    }
}
