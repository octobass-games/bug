using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRoomSwitcher : MonoBehaviour
{
    public Room CurrentRoom;
    public List<Room> Rooms;

    void Awake()
    {
        Rooms.ForEach(room =>
        {
            room.gameObject.SetActive(room.IsInitialRoom);
            room.Camera.SetActive(room.IsInitialRoom);

            if (room.IsInitialRoom)
            {
                CurrentRoom = room;
            }
        });
    }

    public void MoveThroughDoor(Door door)
    {
        if (door.RoomA != CurrentRoom && door.RoomB != CurrentRoom)
        {
            return;
        }

        var newRoom = door.MoveThroughDoor();
        door.transform.SetParent(newRoom.transform);

        CurrentRoom = newRoom;

        Rooms.ForEach(room =>
        {
            if (room != newRoom)
            {
                if (room.isActiveAndEnabled)
                {
                    room.FallOut();
                }
            }
            else
            {
                room.FallIn(door);
            }
        });
    }
}