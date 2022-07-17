using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PhysicsPointerInteractor))]
[RequireComponent(typeof(NavigationPointerInteractor))]
public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private PhysicsPointerInteractor physicsPointerInteractor;
    [SerializeField] private NavigationPointerInteractor navigationPointerInteractor;

    private void OnEnable()
    {
        navigationPointerInteractor.OnInteraction += OnNavigationInteraction;
    }

    private void OnDisable()
    {
        navigationPointerInteractor.OnInteraction -= OnNavigationInteraction;
    }

    private void OnNavigationInteraction(NavMeshHit hit)
    {
        if (hit.hit)
        {
            if ((navMeshAgent.areaMask & hit.mask) != 0)
            {
                Move(hit.position);
            }
        }
    }

    private void Move(Vector3 position)
    {
        navMeshAgent.destination = position;
    }
}
