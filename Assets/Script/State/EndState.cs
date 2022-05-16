using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : State
{

    public override IEnumerator StartPhase(StateManager stateManager)
    {
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
        Debug.Log("end turn");
        yield return null;
        stateManager.ChangeChar();
        stateManager.currState = null; 

    }

}
