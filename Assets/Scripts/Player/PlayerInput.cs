using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private ElementSelection elementSelection;
    private readonly HashSet<InputAction> _inputActions = new HashSet<InputAction>();

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
        InputAction[] actions = new InputAction[]
        {
         new MoveToPointAction(agent),
         new SelectElementAction(0, KeyCode.Alpha1 , elementSelection),
         new SelectElementAction(1, KeyCode.Alpha2 , elementSelection),
         new SelectElementAction(2, KeyCode.Alpha3, elementSelection),
         new SelectElementAction(3, KeyCode.Alpha4, elementSelection),
         new ResetElementsAction(elementSelection),
         new CastSpellAction(elementSelection, () => Input.GetMouseButtonDown(0), transform)
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
