using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Crop : MonoBehaviour
{
    public CropSO cropSO;
    public List<Transform> growthStages = new();

    int currentStage;
    float stageGrowthTime;
    bool needWater;
    void Start()
    {
        currentStage = 0;
        stageGrowthTime = cropSO.growthTime/(growthStages.Count - 2);
        StartCoroutine(CropGrowth());
    }

    public void Interaction()
    {
        if (currentStage != growthStages.Count - 1)
        {
            WaterPlant();
            return;
        }

        else Harvest();

    }

    void Harvest()
    {
        transform.parent.GetComponent<FarmLand>().MakeAvaliable();

        SellCrop();

        Destroy(gameObject);
    }

    void SellCrop()
    {
        int value = cropSO.sellCost;
        Player.instance.AddCoins(value);
    }


    IEnumerator CropGrowth()
    {
        while (currentStage != growthStages.Count - 1)
        {
            needWater = true;
            GetComponent<BoxCollider>().enabled = true;
            Debug.Log("agua");

            while (needWater)
            {
                yield return null;
            }

            Debug.Log("obrigada");
            GetComponent<BoxCollider>().enabled = false;
            NextStage();

            yield return new WaitForSeconds(stageGrowthTime);
        }

        Debug.Log("Pronto para colher");
        GetComponent<BoxCollider>().enabled = true;
    }

    void NextStage()
    {
        growthStages[currentStage].gameObject.SetActive(false);
        currentStage++;
        growthStages[currentStage].gameObject.SetActive(true);
    }

    void WaterPlant()
    {
        if (!Player.instance.holdingWateringCan) return;
        Player.instance.SubtractCoins(cropSO.managementCost);
        needWater = false;
    }
}
