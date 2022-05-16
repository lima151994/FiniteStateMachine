using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract IEnumerator StartPhase(StateManager stateManager);
    public abstract IEnumerator DecisionPhase(StateManager stateManager);
    public abstract IEnumerator ExecutePhase(StateManager stateManager);
    public abstract IEnumerator EndPhase(StateManager stateManager);

}
