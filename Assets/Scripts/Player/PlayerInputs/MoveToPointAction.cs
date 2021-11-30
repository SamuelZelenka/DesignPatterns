using UnityEngine;
using UnityEngine.AI;

public class MoveToPointAction : InputAction
{
    private NavMeshAgent _agent;

    protected override bool IsPressed => Input.GetMouseButton(1);

    public MoveToPointAction(NavMeshAgent agent)
    {
        _agent = agent;
    }

    protected override void Execute()
    {
        _agent.SetDestination(PlayerInput.MouseClickPos());
    }
}
