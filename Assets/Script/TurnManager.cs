using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] StateManager selectedStateManager;
    Coroutine stateCoroutine;
    Queue<IEnumerator> statePhaseQueue = new Queue<IEnumerator>();

    [SerializeField] List<StateManager> selectableStateManager;

    private void Start()
    {
        selectedStateManager.Restart();
    }

    public void EnqueueStatePhase(IEnumerator phase)
    {
        statePhaseQueue.Enqueue(phase);

        stateCoroutine = StartCoroutine(statePhaseQueue.Dequeue());
    }

    public void ChangeChar()
    {
        StateManager state = selectableStateManager[0];
        selectableStateManager.RemoveAt(0);
        selectedStateManager = state;
        selectableStateManager.Add(state);

        selectedStateManager.Restart();
    }
}
