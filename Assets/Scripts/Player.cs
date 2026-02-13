using UnityEngine;

public class Player : MonoBehaviour
{
    public int coins = 0;
    public int coinsNeeded = 250;

    public static Player instance;

    public bool holdingItem = false;
    public bool holdingWheelBarrel = false;
    public bool holdingWateringCan = false;
    public bool holdingHoe = false;

    public Transform heldItem;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void SubtractCoins(int value)
    {
        coins -= value;
        HUDManager.instance.UpdateText();
    }
    public void AddCoins(int value)
    {
        coins += value;
        HUDManager.instance.UpdateText();
    }

    public void CheckWhatItemIsHeld()
    {
        if (heldItem.gameObject.GetComponent<WheelBarrel>() == true)
        {
            holdingWheelBarrel = true;
            holdingWateringCan = false;
            holdingHoe = false;
}

        else if (heldItem.gameObject.GetComponent<WateringCan>() == true)
        {
            holdingWateringCan = true;
            holdingHoe = false;
            holdingWheelBarrel = false;
        }

        else if (heldItem.gameObject.GetComponent<Hoe>() == true)
        {
            holdingHoe = true;
            holdingWheelBarrel = false;
            holdingWateringCan = false;
        }
    }
}
