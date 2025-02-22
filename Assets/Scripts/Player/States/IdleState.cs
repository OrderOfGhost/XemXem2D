using UnityEngine;

public class IdleState : IState
{
    private Animator animator;
    private StateController sc;
    public IdleState(StateController sc, Animator animator)
    {
        this.animator = animator;
    }

    public void OnEnter(StateController sc)
    {
        Debug.Log("Entering Idle State");
        animator.Play("Idle");
    }

    public void OnUpdate(StateController sc)
    {
        Debug.Log("Updating Idle State");
    }

    public void OnExit(StateController sc)
    {
        Debug.Log("Exiting Idle State");
    }
}

