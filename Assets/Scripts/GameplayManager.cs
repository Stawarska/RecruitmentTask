using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance { get; private set; }

    [field: SerializeField] public List<Player> Players { get; private set; }
    
    private void Awake()
    {
        Assert.IsNull(Instance);
        Instance = this;
    }
    
    public void SwitchGuide(int playerIndex)
    {
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].IsGuide = i == playerIndex;
        }
    }
}
