using TMPro;
using UnityEngine;

public class FarmLand : MonoBehaviour
{
    public int sellCost = 10;
    public int plowCost = 1;
    public Transform sign;
    public Transform plowedDirt;

    Transform crop;
    bool isBought = false;
    bool isPlowed = false;

    private void Start()
    {
        sign.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = sellCost.ToString();
    }

    public void MakeAvaliable()
    {
        if (crop == null)
        {
            isPlowed = false;
            plowedDirt.gameObject.SetActive(false);
            GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void TryToPlant()
    {

        if (isBought)
        {
            if (isPlowed)
            {
                GetSeed();
            }

            else PlowDirt();
        }

        else
        {
            TryToBuy();
        }

    }

    void PlowDirt()
    {
        if (!Player.instance.holdingHoe) return;
        Player.instance.SubtractCoins(plowCost);
        isPlowed = true;
        plowedDirt.gameObject.SetActive(true);
    }

    void GetSeed()
    {
        if (!Player.instance.holdingWheelBarrel) return;
        WheelBarrel.instance.TakeSeed();
        Transform seed = WheelBarrel.instance.nextSeed;
        PlantSeed(seed);
    }

    void PlantSeed(Transform seed)
    {
        if (seed == null) return;

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
