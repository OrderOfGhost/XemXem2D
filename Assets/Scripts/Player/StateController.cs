using UnityEngine;
using UnityEngine.Rendering;

public class StateController
{
    IState currentState;
    public Animator animator;
    public Rigidbody2D rb;

    public IdleState idleState;
    public RunState runState;
    public RollState rollState;
    public JumpState jumpState;
    public AttackState attackState;
    public Attack2State attack2State;
    public CrouchState crouchState;
    public DeathState deathState;

    public StateController(Animator animator, Rigidbody2D rb)
    {
        this.animator = animator;
        this.rb = rb;
        idleState = new IdleState(this,animator);
        runState = new RunState(animator);
        rollState = new RollState(animator);
        jumpState = new JumpState(animator, rb, this);
        attackState = new AttackState(animator);
        attack2State = new Attack2State(animator);
        crouchState = new CrouchState(animator);
        deathState = new DeathState(animator);
        ChangeState(idleState);
    }

    public StateController()
    {
        ChangeState(idleState);
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate(this);
        }
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        currentState.OnEnter(this);
    }
}
