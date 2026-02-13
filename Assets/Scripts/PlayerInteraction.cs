using UnityEditor.Rendering;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("FarmLand"))
        {
            other.gameObject.GetComponent<FarmLand>().TryToPlant();
            return;
        }

        if (other.gameObject.CompareTag("Item"))
        {
            if (!Player.instance.holdingItem)
            {
                other.gameObject.GetComponent<HeldItem>().EquipItem();
                Player.instance.CheckWhatItemIsHeld();
                return;
            }

            else
            {
                Player.instance.heldItem.gameObject.GetComponent<HeldItem>().UnequipItem();
                other.gameObject.GetComponent<HeldItem>().EquipItem();
                Player.instance.CheckWhatItemIsHeld();
                return;
            }
        }

        if (other.gameObject.CompareTag("ShopArea"))
        {
            other.gameObject.GetComponent<ShopArea>().TrySell();
            return;
        }

        if (other.gameObject.CompareTag("Crop"))
        {
            other.gameObject.GetComponent<Crop>().Interaction();
            return;
        }
    }
}
