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
            wheelBarrel.GetComponent<WheelBarrel>().TakeSeed();
            Transform seed = wheelBarrel.GetComponent<WheelBarrel>().nextSeed;
            other.gameObject.GetComponent<FarmLand>().PlantSeed(seed);
        }

        if (other.gameObject.CompareTag("WheelBarrel"))
        {
            other.gameObject.GetComponent<WheelBarrel>().CarryingByPlayer(wheelBarrelPosition);
            wheelBarrel = other.gameObject;
        }

        if (other.gameObject.CompareTag("SeedBag"))
        {
            wheelBarrel.GetComponent<WheelBarrel>().LoadSlot(other.gameObject.transform);
        }
    }
}
