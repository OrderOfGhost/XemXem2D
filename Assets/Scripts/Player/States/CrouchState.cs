using UnityEngine;

public class CrouchState : IState
{
    private Animator animator;
    public CrouchState(Animator animator)
    {
        this.animator = animator;
    }
    public void OnEnter(StateController sc)
    {
        Debug.Log("Entering Crouch State");
        animator.Play("Crouch");
    }

    public void OnUpdate(StateController sc)
    {
        Debug.Log("Updating Crouch State");
    }

    public void OnExit(StateController sc)
    {
        Debug.Log("Exiting Crouch State");
    }
}

