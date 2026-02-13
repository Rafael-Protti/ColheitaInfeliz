using UnityEngine;
using UnityEngine.UIElements;

public class HeldItem : MonoBehaviour
{
    public Transform heldPosition;

    Vector3 starterPosition;
    Quaternion starterRotation;
    void Start()
    {
        if (heldPosition == null)
        { 
            Debug.Log("INSERIR HELD POSITION");
            return;
        }

        starterPosition = transform.position;
        starterRotation = transform.rotation;
    }
    public void EquipItem()
    {
        transform.position = heldPosition.transform.position;
        transform.rotation = heldPosition.transform.rotation;
        transform.SetParent(heldPosition.transform, true);
        GetComponent<BoxCollider>().enabled = false;
        Player.instance.holdingItem = true;
        Player.instance.heldItem = transform;
    }

    public void UnequipItem()
    {
        transform.SetParent(null);
        transform.position = starterPosition;
        transform.rotation = starterRotation;
        GetComponent<BoxCollider>().enabled = true;
        Player.instance.holdingItem = false;
    }


}
