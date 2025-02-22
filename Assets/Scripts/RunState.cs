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

public class JumpState : IState
{
    private Animator animator;
    private Rigidbody2D rb;
    private StateController stateController;
    private float groundCheckDistance = 3.4f;
    int groundLayerMask = LayerMask.GetMask("Ground");

    public JumpState(Animator animator, Rigidbody2D rb, StateController stateController)
    {
        this.animator = animator;
        this.rb = rb;
        this.stateController = stateController;
    }

    public void OnEnter(StateController sc)
    {
        Debug.Log("Entering Jump State");
        animator.Play("Jumping");
        rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
    }

    public void OnUpdate(StateController sc)
    {
        float yVelocity = rb.linearVelocityY;
        animator.SetFloat("YVelocity", yVelocity);

        if (yVelocity < 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, groundCheckDistance, groundLayerMask);
            Debug.DrawRay(rb.position, Vector2.down * groundCheckDistance, Color.red, 0.1f);
            if (hit.collider != null)
            {
                stateController.ChangeState(stateController.idleState);
            }
        }
    }


    public void OnExit(StateController sc)
    {
        Debug.Log("Exiting Jump State");
    }
}



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

