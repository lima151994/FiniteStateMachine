using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public override IEnumerator StartPhase(StateManager stateManager)
    {
        Debug.Log("mulai attack " + Time.time);
        yield return new WaitForSeconds(0.5f);

        stateManager.EnqueueStatePhase(DecisionPhase(stateManager));
    }
 
    public override IEnumerator DecisionPhase(StateManager stateManager)
    {
        Debug.Log("lagi attack " + Time.time);
        yield return new WaitForSeconds(0.5f);

        IEnumerator phase = DecisionPhase(stateManager);

        /*
         * if trigger end > phase = endphase
         */

        stateManager.EnqueueStatePhase(phase);
    }

    public override IEnumerator ExecutePhase(StateManager stateManager)
    {
        yield return null;
        stateManager.EnqueueStatePhase(EndPhase(stateManager));
    }

    public override IEnumerator EndPhase(StateManager stateManager)
    {
        Debug.Log("end move");
       
        stateManager.ChangeState(stateManager.menuState);

        yield return null;


    }
}
