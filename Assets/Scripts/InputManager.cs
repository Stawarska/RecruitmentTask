using System;
using UnityEngine.Assertions;

public class InputManager 
{
    public static InputManager Instance => instance ?? new InputManager();

    private static InputManager instance;

    public event Action OnMouseClickInput;

    private readonly InputActions playerInputs;


    private InputManager()
    {
        Assert.IsNull(instance);
        instance = this;
        playerInputs = new InputActions();

        playerInputs.Gameplay.MouseClick.performed += (_) => OnMouseClickInput?.Invoke();

        EnableInput();
    }

    public void EnableInput() => playerInputs.Enable();

    public void DisableInput() => playerInputs.Disable();
}
