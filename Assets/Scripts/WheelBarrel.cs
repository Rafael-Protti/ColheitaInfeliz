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

    Vector3 starterPosition;
    Quaternion starterRotation;

    public static WheelBarrel instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        starterPosition = transform.position;
        starterRotation = transform.rotation;
    }

    public void EquipWheelBarrel(Transform playerFront)
    {
        transform.position = playerFront.position;
        transform.rotation = playerFront.rotation;
        transform.SetParent(playerFront, true);
        GetComponent<BoxCollider>().enabled = false;
    }

    public void UnequipWheelBarrel()
    {
        transform.SetParent(null);
        transform.position = starterPosition;
        transform.rotation = starterRotation;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void LoadSlot(Transform seedBag)
    {
        if(seedSlots.Count >= maxSeeds) return;

        Transform instanciated = Instantiate(seedBag);

        seedSlots.Add(instanciated);
        int num = seedSlots.Count - 1;
        instanciated.transform.position = slots[num].transform.position;
        instanciated.transform.rotation = slots[num].transform.rotation;
        instanciated.transform.SetParent(slots[num], true);
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
