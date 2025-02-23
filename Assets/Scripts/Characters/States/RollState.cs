using UnityEngine;

public class RollState : IState
{
    private Animator animator;
    public RollState(Animator animator)
    {
        this.animator = animator;
    }

    public void OnEnter(StateController sc)
    {
        Debug.Log("Entering Roll State");
        animator.Play("Roll");
    }

    public void OnUpdate(StateController sc)
    {
        Debug.Log("Updating Roll State");
    }

    public void OnExit(StateController sc)
    {
        Debug.Log("Exiting Roll State");
    }
}

