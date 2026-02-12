using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class WheelBarrel : MonoBehaviour
{
    public List<Transform> slots = new();
    public int maxSeeds = 3;
    public Transform nextSeed;

    public List<Transform> seedSlots = new();

    public void CarryingByPlayer(Transform playerFront)
    {
        transform.position = playerFront.position;
        transform.rotation = playerFront.rotation;
        transform.SetParent(playerFront, true);
        GetComponent<BoxCollider>().enabled = false;
    }

    public void LoadSlot(Transform seedBag)
    {
        if(seedSlots.Count >= maxSeeds) return;
        seedSlots.Add(seedBag);
        int num = seedSlots.Count - 1;
        seedBag.transform.position = slots[num].transform.position;
        seedBag.transform.rotation = slots[num].transform.rotation;
        seedBag.transform.SetParent(slots[num], true);
    }

    public void TakeSeed()
    {
        if(seedSlots.Count < 1) return;
        nextSeed = seedSlots[0];
        seedSlots[0].SetParent(null);
        seedSlots.RemoveAt(0);
        ReorganizeSeedSlots();
    }

    void ReorganizeSeedSlots()
    {
        for (int index = 0; index < seedSlots.Count; index++)
        {
            seedSlots[index].transform.position = slots[index].transform.position;
            seedSlots[index].transform.rotation = slots[index].transform.rotation;
            seedSlots[index].transform.SetParent(slots[index], true);
        }
    }
}
