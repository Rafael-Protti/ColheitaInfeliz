using UnityEngine;

public class ShopArea : MonoBehaviour
{
    public Transform seedBag;
    int seedValue;
    Transform seed;
    public void TrySell()
    {
        seedValue = seedBag.GetComponent<Seed>().seedSO.buyCost;
        seed = seedBag.GetComponent<Seed>().seedSO.seedBagObject.transform;

        if (Player.instance.coins >= seedValue)
        {
            Player.instance.SubtractCoins(seedValue);
            WheelBarrel.instance.LoadSlot(seed.transform);
        }

        else return;
    }
}
