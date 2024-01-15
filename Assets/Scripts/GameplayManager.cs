using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance => instance;
    
    private static GameplayManager instance = null;

    [field: SerializeField] public List<Player> Players { get; private set; }
    
    private void Awake()
    {
        Assert.IsNull(instance);
        instance = this;
    }
    
    public void SwitchGuide(int playerIndex)
    {
        Debug.Log(playerIndex);
        Players[playerIndex].IsGuide = true;
        foreach (var player in Players.Where(player => player != Players[playerIndex]))
        {
            player.IsGuide = false;
        }
    }
}
