using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomSwitcher : MonoBehaviour
{
    public List<GameObject> Rooms;
    public List<GameObject> RoomsCamera;
    public int CurrentRoomIndex = 0;

    private Coroutine FallOutCoroutine;
    private int LastRoomIndex;

    void Awake()
    {
        Rooms.ForEach(room => room.gameObject.SetActive(false));
        Rooms[CurrentRoomIndex].SetActive(true);
    }

    public void NextRoom()
    {
        var currentRoom = Rooms[CurrentRoomIndex];
        var currentFallIns = currentRoom.GetComponentsInChildren<Fall>().ToList();
        RoomsCamera[CurrentRoomIndex].SetActive(false);

        CurrentRoomIndex = Rooms.NextIndex(CurrentRoomIndex);
        var newRoom = Rooms[CurrentRoomIndex];
        newRoom.SetActive(true);
        RoomsCamera[CurrentRoomIndex].SetActive(true);
        var fallIns = newRoom.GetComponentsInChildren<Fall>().ToList();

        if (FallOutCoroutine != null)
        {
            StopCoroutine(FallOutCoroutine);
        }

        FallOutCoroutine = StartCoroutine(WaitThen(() => currentFallIns.ForEach(f => f.FallOut())));

        fallIns.ForEach(f => f.FallIn());
    }

    public void GoToIndex(int index)
    {
        var currentRoom = Rooms[CurrentRoomIndex];
        var currentFallIns = currentRoom.GetComponentsInChildren<Fall>().ToList();
        RoomsCamera[CurrentRoomIndex].SetActive(false);

        if (FallOutCoroutine != null && LastRoomIndex == index)
        {
            StopCoroutine(FallOutCoroutine);
        }

        LastRoomIndex = CurrentRoomIndex;
        CurrentRoomIndex = index;
        var newRoom = Rooms[CurrentRoomIndex];
        newRoom.SetActive(true);
        RoomsCamera[CurrentRoomIndex].SetActive(true);
        var fallIns = newRoom.GetComponentsInChildren<Fall>().ToList();


        FallOutCoroutine = StartCoroutine(WaitThen(() => currentFallIns.ForEach(f => f.FallOut())));

        fallIns.ForEach(f => f.FallIn());
    }

    IEnumerator WaitThen(Action cb)
    {
        yield return new WaitForSeconds(1);
        cb();
    }
}