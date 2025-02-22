using UnityEngine;

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

