using UnityEngine;

public class FarmLand : MonoBehaviour
{
    Transform crop;
    public void PlantSeed(Transform seed)
    {
        if (seed == null) return;
        Transform instanciated = Instantiate(seed.gameObject.GetComponent<Seed>().seedSO.cropObject);
        instanciated.transform.position = transform.position;
        instanciated.transform.rotation = transform.rotation;
        instanciated.transform.SetParent(transform);
        Destroy(seed.gameObject);
        GetComponent<BoxCollider>().enabled = false;
    }

    public void CheckIfAvaliable()
    {
        if (crop == null)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
    }
}
