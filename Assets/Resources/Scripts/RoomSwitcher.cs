using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class RoomSwitcher : MonoBehaviour
{
    public List<GameObject> Rooms;
    public List<GameObject> RoomsCamera;
    public Dictionary<GameObject, List<Fall>> Fallins = new Dictionary<GameObject, List<Fall>>();

    private Coroutine coroutine;

    public int CurrentRoomIndex = 0;

    void Start()
    {
        Rooms.ForEach(r =>
        {
            Fallins.Add(r, r.GetComponentsInChildren<Fall>().ToList());
            r.gameObject.SetActive(false);
        });

        Rooms[CurrentRoomIndex].SetActive(true);
    }

    public void NextRoom()
    {
        var oldRoom = Rooms[CurrentRoomIndex];
        var oldFallins = Fallins[oldRoom];
        RoomsCamera[CurrentRoomIndex].SetActive(false);

        CurrentRoomIndex = Rooms.NextIndex(CurrentRoomIndex);

        var room = Rooms[CurrentRoomIndex];
        room.SetActive(true);
        RoomsCamera[CurrentRoomIndex].SetActive(true);
        var fallIns = Fallins[room];

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        coroutine = StartCoroutine(WaitThen(() => oldFallins.ForEach(f => f.FallOut())));

        fallIns.ForEach(f => f.FallIn());
    }



    IEnumerator WaitThen(Action cb)
    {
        yield return new WaitForSeconds(1);
        cb();
    }

}