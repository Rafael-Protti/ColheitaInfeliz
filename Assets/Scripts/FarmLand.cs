using UnityEngine;

public class FarmLand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Plantando...");
    }

    public void PlantSeed(Transform seed)
    {
        Transform instanciated = seed;
        Instantiate(instanciated);
        instanciated.position = transform.position;
        GetComponent<BoxCollider>().enabled = false;
    }
}
