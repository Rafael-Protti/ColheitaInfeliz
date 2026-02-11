using UnityEditor.Rendering;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform seed;
    public Transform wheelBarrelPosition;
    GameObject wheelBarrel;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("FarmLand"))
        {
            Debug.Log("Encostou no lote de terra");
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
