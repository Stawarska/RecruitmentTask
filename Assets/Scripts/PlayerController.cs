using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Player player;
    [SerializeField] private float playerDistance;
    

    private void Awake()
    {
        InputManager.Instance.OnMouseClickInput += SetDestinationOnClick;
    }

    private void Start()
    {
        agent.speed = player.Speed;
    }

    private void Update()
    {
        FollowGuide();
    }

    private void SetDestinationOnClick()
    {
        if (player.IsGuide)
        {
            var ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out var hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        else
        {
            FollowGuide();
        }
    }

    private void FollowGuide()
    {
        if (player.IsGuide) 
            return;
        
        Player guidePlayer = null;
        
        foreach (var otherPlayer in GameplayManager.Instance.Players)
        {
            if (!otherPlayer.IsGuide) 
                continue;
            
            guidePlayer = otherPlayer;
            break;
        }

        if (guidePlayer == null) 
            return;
        
        var guidePosition = guidePlayer.transform.position;
        agent.SetDestination(guidePosition + (player.transform.position - guidePosition).normalized * playerDistance);
    }
}
