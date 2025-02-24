using UnityEngine;
using UnityEngine.Rendering;
using Characters.Player;
using System.Collections.Generic;
public class StateController
{
    IState currentState;
    public Animator animator;
    public Rigidbody2D rb;

    private readonly Dictionary<PlayerAction, IState> stateDictionary;

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
        stateDictionary = new Dictionary<PlayerAction, IState>
        {
            {PlayerAction.Idle, new IdleState(this,animator)},
            {PlayerAction.Run, new RunState(animator)},
            {PlayerAction.Roll, new RollState(animator)},
            {PlayerAction.Jump, new JumpState(animator,rb, this)},
            {PlayerAction.Attack, new AttackState(animator)},
            {PlayerAction.Attack2, new Attack2State(animator)},
            {PlayerAction.Crouch, new CrouchState(animator)},
            {PlayerAction.Death, new DeathState(animator)}
        };
        ChangeState(stateDictionary[PlayerAction.Idle]);
    }

    public void Update()
    {
        currentState?.OnUpdate(this);
    }

    public void ChangeState(IState newState)
    {
        currentState?.OnExit(this);
        currentState = newState;
        currentState?.OnEnter(this);
    }

    public void ChangeStateByAction(PlayerAction action)
    {
        if(stateDictionary.TryGetValue(action, out IState state))
        {
            ChangeState(state);
        }
    }
}
