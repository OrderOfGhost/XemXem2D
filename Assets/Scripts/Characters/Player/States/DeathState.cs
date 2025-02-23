using UnityEngine;

public class DeathState : IState
{
    private Animator animator;
    public DeathState(Animator animator)
    {
        this.animator = animator;
    }
    public void OnEnter(StateController sc)
    {
        Debug.Log("Entering Death State");
        animator.Play("Death");
    }

    public void OnUpdate(StateController sc)
    {
        Debug.Log("Updating Death State");
    }

    public void OnExit(StateController sc)
    {
        Debug.Log("Exiting Death State");
    }
}

