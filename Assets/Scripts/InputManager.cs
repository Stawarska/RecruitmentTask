using System;
using UnityEngine.Assertions;

public class InputManager 
{
    public static InputManager Instance => instance ?? new InputManager();

    private static InputManager instance = null;

    public event Action OnMouseClickInput;

    private readonly InputActions playerInputs = null;


    public InputManager()
    {
        Assert.IsNull(instance);
        instance = this;
        playerInputs = new InputActions();

        playerInputs.Gameplay.MouseClick.performed += (ctx) => OnMouseClickInput?.Invoke();

        EnableInput();
    }

    public void EnableInput() => playerInputs.Enable();

    public void DisableInput() => playerInputs.Disable();
}
