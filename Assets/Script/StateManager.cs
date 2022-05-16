using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateManager : MonoBehaviour
{
    public NavMeshAgent agent;

    public bool hasMoved;

    [SerializeField] TurnManager turnManager;

    public State currState;
    public MovementState moveState;
    public AttackState attackState;
    public MenuState menuState;
    public StartState startState;
    public EndState endState;

    [SerializeField] Animator animator;


    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    public void ChangeState(State state)
    {
        currState = state;
        EnqueueStatePhase(currState.StartPhase(this));
    }

    public void EnqueueStatePhase(IEnumerator phase)
    {
        turnManager.EnqueueStatePhase(phase);
    }
    public void ChangeChar()
    {
        turnManager.ChangeChar();
    }
    public void Restart()
    {
        currState = startState;
        hasMoved = false;
        EnqueueStatePhase(currState.StartPhase(this));
    }

  
}
