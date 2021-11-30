using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private ElementSelection selectionUI;
    private HashSet<InputAction> _inputActions = new HashSet<InputAction>();
    private void Start()
    {
        CreateInputKeys();
    }
    void Update()
    {
        foreach (InputAction action in _inputActions)
        {
            action.CheckIfPressed();
        } 
    }
    private void CreateInputKeys()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        InputAction[] actions = new InputAction[6]
        {
         new MoveToPointAction(agent, MouseClickPos()),
         new SelectElementAction(0, KeyCode.Alpha1 , selectionUI),
         new SelectElementAction(1, KeyCode.Alpha2 , selectionUI),
         new SelectElementAction(2, KeyCode.Alpha3, selectionUI),
         new SelectElementAction(3, KeyCode.Alpha4, selectionUI),
         new ResetElementsAction(selectionUI)
        };

        for (int i = 0; i < actions.Length; i++)
        {
            _inputActions.Add(actions[i]);
        }
    }
    
    private static Camera _mainCamera;
    private static Camera MainCamera
    {
        get
        {
            _mainCamera = _mainCamera != null ? _mainCamera : Camera.main;
            return _mainCamera;
        }
    }

    public static Vector3 MouseClickPos()
    {
        RaycastHit hit;
        Ray mouseToWorldRay = MainCamera.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(mouseToWorldRay, out hit);

        return hit.point;
    }
}
