using UnityEngine;

public class ThirdPersonChar : MonoBehaviour
{
    public float rotationSpeed = 5;
    void Update()
    {
        Vector3 move3 = new Vector3(MovimentEvent.instance.move.x, 0, MovimentEvent.instance.move.y);

        if (move3.magnitude >= 0.1)
        {
            Quaternion destinoRotacao = Quaternion.LookRotation(move3, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, destinoRotacao, rotationSpeed * Time.deltaTime);
        }
    }
}
