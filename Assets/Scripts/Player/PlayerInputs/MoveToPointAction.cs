using UnityEngine;
using UnityEngine.AI;

public class MoveToPointAction : InputAction
{
    private Vector3 _point;
    private NavMeshAgent _agent;

    protected override bool IsPressed => Input.GetMouseButton(0);

    public MoveToPointAction(NavMeshAgent agent, Vector3 clickedPos)
    {
        _agent = agent;
        _point = clickedPos;
    }

    protected override void Execute()
    {
        _agent.SetDestination(_point);
    }
}
