using UnityEngine;

public class RunState : IState
{
    private Animator animator;
    public RunState(Animator animator)
    {
        this.animator = animator;
    }

    public void OnEnter(StateController sc)
    {
        Debug.Log("Entering Run State");
        animator.Play("Run");
    }

    public void OnUpdate(StateController sc)
    {
        Debug.Log("Updating Run State");
    }

    public void OnExit(StateController sc)
    {
        Debug.Log("Exiting Run State");
    }
}

