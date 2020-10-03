using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransitionWaypoint : MonoBehaviour
{
    [SerializeField] private RoomTransitionWaypointData roomToTransitTo = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rooms.roomsInstance.TransitToRoom(roomToTransitTo);
    }
}
