using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    private GameRooms currentRoom = GameRooms.HALL;

    public static Rooms roomsInstance;
    [SerializeField] private GameObject mainCamara = null;
    [SerializeField] private GameObject player = null;

    public enum GameRooms
    {
        HALL,
        GARDEN
    }

    private void Awake()
    {
        if (roomsInstance != null) Debug.LogError("More than 1 roomsInstance in scene! Use only one");
        roomsInstance = this;
    }

    public void TransitToRoom(RoomTransitionWaypointData roomData)
    {
        Debug.Log("Transiting to room: " + roomData.roomToTransitTo.ToString());
        currentRoom = roomData.roomToTransitTo;
        mainCamara.transform.position = roomData.newCamaraPosistion;
        player.transform.position = roomData.newPlayerPosistion;
    }
}
