using UnityEngine;

[CreateAssetMenu(fileName = "RoomTransitionWaypointData", menuName = "ScriptableObjects/RoomTransitionWaypointData", order = 1)]
public class RoomTransitionWaypointData : ScriptableObject
{
    public Rooms.GameRooms roomToTransitTo;
    public Vector3 newCamaraPosistion;
    public Vector3 newPlayerPosistion;
}
