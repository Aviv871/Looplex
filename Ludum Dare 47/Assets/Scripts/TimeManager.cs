using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager timeManagerInstance;

    // The action to be executated at the event, takes the delta since the wanted event time to now
    public delegate void TimeEventFunc(float timeDelta);
    private Dictionary<float, List<TimeEventFunc>> timeEvents = new Dictionary<float, List<TimeEventFunc>>();

    private void Awake()
    {
        if (timeManagerInstance != null) Debug.LogError("More than 1 timeManagerInstance in scene! Use only one");
        timeManagerInstance = this;
        timeEvents.Clear();
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
