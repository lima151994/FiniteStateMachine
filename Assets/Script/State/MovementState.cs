using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MovementState : State
{
    [SerializeField]Transform target;
    Camera cam;
    [SerializeField]Vector3 targetMovement;

    [SerializeField] CinemachineVirtualCamera playerCam;

    private void Start()
    {
        cam = Camera.main;
    }
    public override IEnumerator StartPhase(StateManager stateManager)
    {
        Debug.Log("start move");
        target.gameObject.SetActive(true);
        playerCam.enabled = false;

        yield return null;

        stateManager.EnqueueStatePhase(DecisionPhase(stateManager));
    }

    public override IEnumerator DecisionPhase(StateManager stateManager)
    {
        Debug.Log("decision move");

        MoveTargetPointer();

        IEnumerator phase = DecisionPhase(stateManager);

        if (Input.GetMouseButtonDown(0))
        {
            targetMovement = target.transform.position;
            
            target.gameObject.SetActive(false);
            playerCam.enabled = true;
            stateManager.agent.SetDestination(targetMovement);

            phase = (ExecutePhase(stateManager));
        }

        yield return null;

        stateManager.EnqueueStatePhase(phase);
    }

    public override IEnumerator ExecutePhase(StateManager stateManager)
    {
        
        Debug.Log("execute move");

        IEnumerator phase = EndPhase(stateManager);

        if (stateManager.agent.remainingDistance>0f)
        {
            phase = (ExecutePhase(stateManager));
        }
    
       
        yield return null;

        stateManager.EnqueueStatePhase(phase);
    }

    public override IEnumerator EndPhase(StateManager stateManager)
    {
        Debug.Log("end move");
        target.gameObject.SetActive(false);
        stateManager.hasMoved = true;
        yield return null;
        stateManager.ChangeState(stateManager.menuState);
    }

    private void MoveTargetPointer()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);

        target.position = hit.point;
    }

  
}
