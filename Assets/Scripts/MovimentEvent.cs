using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentEvent : MonoBehaviour
{

    public Vector2 move;
    InputAction inputMove;

    public static MovimentEvent instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        inputMove = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        move = inputMove.ReadValue<Vector2>();
    }
}
