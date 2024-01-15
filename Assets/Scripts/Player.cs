using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed { get; private set; }
    public int Agility { get; private set; }
    public int Strength { get; private set; }
    public bool IsGuide { get; set; }
    
    [SerializeField] private PlayerDefinition definition;
    
    private void Awake()
    {
        SetRandomValues();
    }

    private void SetRandomValues()
    {
        Speed = Random.Range(definition.MinSpeed, definition.MaxSpeed);
        Agility = Random.Range(definition.MinAgility, definition.MaxAgility);
        Strength = Random.Range(definition.MinStrength, definition.MaxStrength);
        Debug.Log($"{name} stats: speed: {Speed}, agility: {Agility}, strength: {Strength}");
    }
}  
