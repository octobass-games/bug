using UnityEngine;

public class Door : MonoBehaviour
{
    public Room RoomA;
    public Room RoomB;

    public void MoveThroughDoor()
    {
        var moveToRoomA = transform.parent == RoomB.transform;

        if (moveToRoomA)
        {
            RoomA.gameObject.SetActive(true);
            RoomA.FallIn();
            RoomA.Camera.SetActive(true);

            transform.SetParent(RoomA.transform);

            RoomB.FallOut();
            RoomB.Camera.SetActive(false);
        }
        else
        {
            RoomB.gameObject.SetActive(true);
            RoomB.FallIn();
            RoomB.Camera.SetActive(true);

            transform.SetParent(RoomB.transform);

            RoomA.FallOut();
            RoomA.Camera.SetActive(false);
        }
    }
}