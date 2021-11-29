using UnityEngine;
using UnityEngine.AI;

public class ClickToMoveAction : InputAction
{
    private Camera _mainCamera;
    private NavMeshAgent _agent;

    protected override bool IsPressed => Input.GetMouseButton(0);

    public ClickToMoveAction(NavMeshAgent agent, Camera mainCamera)
    {
        _agent = agent;
        _mainCamera = mainCamera;
    }

    protected override void Execute()
    {
        RaycastHit hit;
        Ray mouseToWorldRay = _mainCamera.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(mouseToWorldRay, out hit);

        Vector3 worldPos = hit.point;

        _agent.SetDestination(worldPos);
    }
}
