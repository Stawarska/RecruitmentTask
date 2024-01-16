using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button player1Button;
    [SerializeField] private Button player2Button;
    [SerializeField] private Button player3Button;

    private void Awake()
    {
        SwitchGuide();
    }

    private void SwitchGuide()
    {
        player1Button.onClick.AddListener(()=> GameplayManager.Instance.SwitchGuide(0));
        player2Button.onClick.AddListener(()=> GameplayManager.Instance.SwitchGuide(1));
        player3Button.onClick.AddListener(()=> GameplayManager.Instance.SwitchGuide(2));
    }
}
