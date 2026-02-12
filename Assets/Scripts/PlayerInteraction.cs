using UnityEditor.Rendering;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform wheelBarrelPosition;
    GameObject wheelBarrel;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("FarmLand") && wheelBarrel != null)
        {
            WheelBarrel.instance.TakeSeed();
            Transform seed = WheelBarrel.instance.nextSeed;
            other.gameObject.GetComponent<FarmLand>().PlantSeed(seed);
            return;
        }

        if (other.gameObject.CompareTag("WheelBarrel"))
        {
            WheelBarrel.instance.EquipWheelBarrel(wheelBarrelPosition);
            wheelBarrel = other.gameObject;
            return;
        }

        if (other.gameObject.CompareTag("ShopArea"))
        {
            WheelBarrel.instance.LoadSlot(other.gameObject.GetComponent<ShopArea>().seedBag);
            return;
        }
    }
}
