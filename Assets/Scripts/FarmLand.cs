using UnityEngine;

public class FarmLand : MonoBehaviour
{
    public void PlantSeed(Transform seed)
    {
        if (seed == null) return;
        Transform instanciated = seed.gameObject.GetComponent<Seed>().seedSO.cropObject;
        instanciated.position = transform.position;
        instanciated.rotation = transform.rotation;
        Instantiate(instanciated);
        Destroy(seed.gameObject);
        GetComponent<BoxCollider>().enabled = false;
    }
}
