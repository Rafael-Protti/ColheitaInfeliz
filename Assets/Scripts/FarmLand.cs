using TMPro;
using UnityEngine;

public class FarmLand : MonoBehaviour
{
    public int sellCost = 10;
    public Transform sign;

    Transform crop;
    bool isBought = false;

    private void Start()
    {
        sign.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = sellCost.ToString();
    }

    public void MakeAvaliable()
    {
        if (crop == null)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void TryToPlant()
    {
        if (isBought)
        {
            WheelBarrel.instance.TakeSeed();
            Transform seed = WheelBarrel.instance.nextSeed;
            PlantSeed(seed);
        }

        else
        {
            TryToBuy();
        }

    }
    void PlantSeed(Transform seed)
    {
        if (seed == null) return;

        if(!Player.instance.holdingWheelBarrel) return;

        Transform instanciated = Instantiate(seed.gameObject.GetComponent<Seed>().seedSO.cropObject);
        instanciated.transform.position = transform.position;
        instanciated.transform.rotation = transform.rotation;
        instanciated.transform.SetParent(transform);
        Destroy(seed.gameObject);
        GetComponent<BoxCollider>().enabled = false;
    }

    void TryToBuy()
    {
        if (Player.instance.coins >= sellCost)
        {
            Player.instance.SubtractCoins(sellCost);
            isBought = true;
            Destroy(sign.gameObject);
            TryToPlant();
        }

        else return;
    }
}
