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
        stageGrowthTime = cropSO.growthTime/(growthStages.Count - 1);
        StartCoroutine(CropGrowth());
    }

    void Update()
    {
        
    }

    IEnumerator CropGrowth()
    {
        while (currentStage != growthStages.Count - 1)
        {
            yield return new WaitForSeconds(stageGrowthTime);
            NextStage();
        }
        GetComponent<BoxCollider>().enabled = true;
    }

    void NextStage()
    {
        growthStages[currentStage].gameObject.SetActive(false);
        currentStage++;
        growthStages[currentStage].gameObject.SetActive(true);
    }

    public void Harvest()
    {
        transform.parent.GetComponent<FarmLand>().MakeAvaliable();

        SellCrop();

        Destroy(gameObject);
    }

    public void SellCrop()
    {
        int value = cropSO.sellCost;
        Player.instance.AddCoins(value);
    }
}
