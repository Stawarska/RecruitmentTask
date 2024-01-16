using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDefinition", menuName = "ScriptableObjects/PlayerDefinition", order = 1)]
public class PlayerDefinition : ScriptableObject
{
    [field: SerializeField] public int MinSpeed { get; private set; }
    [field: SerializeField] public int MaxSpeed { get; private set; }
    [field: SerializeField] public int MinAgility { get; private set; }
    [field: SerializeField] public int MaxAgility { get; private set; }
    [field: SerializeField] public int MinStrength { get; private set; }
    [field: SerializeField] public int MaxStrength { get; private set; }
}
