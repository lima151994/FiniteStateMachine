using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartState : State
{
    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] CinemachineTargetGroup targetGroup;

    public override IEnumerator StartPhase(StateManager stateManager)
    {
        playerCam.Follow = stateManager.agent.transform;
        playerCam.LookAt = stateManager.agent.transform;
        
        if(targetGroup.m_Targets.Length>1)
            targetGroup.RemoveMember(targetGroup.m_Targets[1].target);
        targetGroup.AddMember(stateManager.agent.transform,1,0);

        yield return null;

        stateManager.EnqueueStatePhase(DecisionPhase(stateManager));
    }

    public override IEnumerator DecisionPhase(StateManager stateManager)
    {
        yield return null;

        stateManager.EnqueueStatePhase(ExecutePhase(stateManager));
    }

    public override IEnumerator ExecutePhase(StateManager stateManager)
    {
        yield return null;

        stateManager.EnqueueStatePhase(EndPhase(stateManager));
    }

    public override IEnumerator EndPhase(StateManager stateManager)
    {
        yield return null;
        stateManager.ChangeState(stateManager.menuState);

    }

}
