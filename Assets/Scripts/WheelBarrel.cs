using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrel : MonoBehaviour
{
    public List<Transform> slots = new();

    List<Transform> seedSlots = new();

    public void CarryingByPlayer(Transform playerFront)
    {
        transform.position = playerFront.position;
        transform.SetParent(playerFront, true);
        GetComponent<BoxCollider>().enabled = false;
    }

    public void LoadSlot(Transform seedBag)
    {
        seedSlots.Add(seedBag);
        int num = seedSlots.Count - 1;
        seedBag.transform.position = slots[num].transform.position;
        seedBag.transform.SetParent(slots[num], true);
    
    }
}
