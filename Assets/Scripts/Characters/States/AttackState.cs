using UnityEngine;

public class AttackState : IState
{
    private Animator animator;
    public AttackState(Animator animator)
    {
        this.animator = animator;
    }

    public void OnEnter(StateController sc)
    {
        Debug.Log("Entering Attack State");
        animator.Play("Attack");
    }

    public void OnUpdate(StateController sc)
    {
        Debug.Log("Updating Attack State");
    }

    public void OnExit(StateController sc)
    {
        Debug.Log("Exiting Attack State");
    }
}

