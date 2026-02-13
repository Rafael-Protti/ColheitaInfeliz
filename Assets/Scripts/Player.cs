using UnityEngine;

public class Player : MonoBehaviour
{
    public int coins = 0;

    public static Player instance;

    public bool holdingItem = false;
    public bool holdingWheelBarrel = false;

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

    public void CheckIfItIsWheelBarrel()
    {
        if (heldItem.gameObject.GetComponent<WheelBarrel>() == true)
        {
            holdingWheelBarrel = true;
        }

        else holdingWheelBarrel = false;
    }
}
