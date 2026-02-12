using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Transform> slots;
    public List<Transform> shopArea;
    public List<SeedSO> seeds;
    void Start()
    {
        DisplaySeeds();
    }

    void DisplaySeeds()
    {
        if (seeds.Count != slots.Count || seeds.Count != shopArea.Count ) return;
        for (int index = 0; index < seeds.Count; index++)
        {
            Transform instanciated = seeds[index].seedBagObject;
            instanciated.position = slots[index].position;
            instanciated.rotation = slots[index].rotation;
            Instantiate(instanciated);
            shopArea[index].GetComponent<ShopArea>().seedBag = seeds[index].seedBagObject;
        }
    }
}
