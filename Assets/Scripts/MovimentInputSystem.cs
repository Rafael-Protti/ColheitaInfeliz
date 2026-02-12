using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentInputSystem : MonoBehaviour
{

    public float speed = 5;

    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 directions = MovimentEvent.instance.move;

        Vector3 moviment = new Vector3(directions.x, -1, directions.y);

        moviment *= speed * Time.deltaTime;

        cc.Move(moviment);
    }
}
