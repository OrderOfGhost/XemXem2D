using UnityEngine;

public class Attack2State : IState
{
    private Animator animator;
    public Attack2State(Animator animator)
    {
        this.animator = animator;
    }
    public void OnEnter(StateController sc)
    {
        Debug.Log("Entering Attack 2 State");
        animator.Play("Attack2");
    }

    public void OnUpdate(StateController sc)
    {
        Debug.Log("Updating Attack 2 State");
    }

    public void OnExit(StateController sc)
    {
        Debug.Log("Exiting Attack 2 State");
    }
}

