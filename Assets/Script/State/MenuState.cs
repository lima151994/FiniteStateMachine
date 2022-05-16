using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : State
{
    [SerializeField] Button moveButton;
    [SerializeField] Button endButton;
    enum targetState
    {
        move,
        attack,
        end
    }

    bool nextStateSelected;

    targetState currTargetState;

    public void selectNextState(int index)
    {
        currTargetState = (targetState)index;
        nextStateSelected = true;
    }

    void AssignButton()
    {
        moveButton.onClick.RemoveAllListeners();
        moveButton.onClick.AddListener(() => selectNextState(0));

        endButton.onClick.RemoveAllListeners();
        endButton.onClick.AddListener(() => selectNextState(2));
    }

    public override IEnumerator StartPhase(StateManager stateManager)
    {
        if(!stateManager.hasMoved)
        moveButton.gameObject.SetActive(true);
        endButton.gameObject.SetActive(true);
        nextStateSelected = false;

        AssignButton();

        Debug.Log("Menu mulai");
        yield return null;

        stateManager.EnqueueStatePhase(DecisionPhase(stateManager));
    }

    public override IEnumerator DecisionPhase(StateManager stateManager)
    {
        Debug.Log("Menu decision");

        IEnumerator phase = DecisionPhase(stateManager);

        if (nextStateSelected)
        {
            phase=(ExecutePhase(stateManager));
        }

        yield return null;
   
        stateManager.EnqueueStatePhase(phase);
    }

    public override IEnumerator ExecutePhase(StateManager stateManager)
    {
        Debug.Log("Menu execute");
        yield return null;
        stateManager.EnqueueStatePhase(EndPhase(stateManager));
    }

    public override IEnumerator EndPhase(StateManager stateManager)
    {
        Debug.Log("Menu end");
        moveButton.gameObject.SetActive(false);
        endButton.gameObject.SetActive(false);
        
        switch (currTargetState)
        {
            case targetState.move:
                stateManager.ChangeState(stateManager.moveState);
                break;
            case targetState.attack:
                break;
            case targetState.end:
                stateManager.ChangeState(stateManager.endState);
                break;
            default:
                break;
        }
        
        yield return null;
 
    }
}
