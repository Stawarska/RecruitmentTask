using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Player player;
    

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
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
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
        if (!player.IsGuide)
        {
            Player guidePlayer = null;
            foreach (var player in GameplayManager.Instance.Players)
            {
                if (player.IsGuide)
                    guidePlayer = player;
            }

            if(guidePlayer != null)
                agent.SetDestination(guidePlayer.transform.position);
        }
    }
}
