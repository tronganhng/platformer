using System;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    InputSystem inputSystem;
    StateManager stateManager;
    public static InputManager instance;
    public float inputDirect;

    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        inputSystem = new InputSystem();
        inputSystem.Enable();

        stateManager = GameObject.FindGameObjectWithTag(Tag.Player).GetComponent<StateManager>();

        inputSystem.Playermap.Direct.performed += ctx =>
        {
            inputDirect = ctx.ReadValue<float>();
        };

        inputSystem.Playermap.Jump.performed += ctx =>
        {
            GameEvents.instance.pressJump?.Invoke(stateManager);
        };
    }
}
