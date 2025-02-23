using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum PlayerAction
{
    Idle,
    Run,
    Roll,
    Jump,
    Attack,
    Attack2,
    Crouch,
    Death
}






public class PlayerController : MonoBehaviour
{
    [Header("Button action")]
    [SerializeField] List<Button> buttons;
    private StateController stateController;
    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        stateController = new StateController(animator, rb);

        foreach (Button button in buttons)
        {
            ButtonAction btnAction = button.GetComponent<ButtonAction>();
            if (btnAction != null)
            {
                PlayerAction action = btnAction.playerAction;
                button.onClick.AddListener(() => HandleButtonClick(action));
            }
        }
    }

    private void Update()
    {
        stateController.Update();
    }

    private void HandleButtonClick(PlayerAction action)
    {
        switch (action)
        {
            case PlayerAction.Idle:
                SetIdleState();
                break;
            case PlayerAction.Run:
                SetRunState();
                break;
            case PlayerAction.Roll:
                SetRollState();
                break;
            case PlayerAction.Jump:
                SetJumpState();
                break;
            case PlayerAction.Attack:
                SetAttackState();
                break;
            case PlayerAction.Attack2:
                SetAttack2State();
                break;
            case PlayerAction.Crouch:
                SetCrouchState();
                break;
            case PlayerAction.Death:
                SetDeathState();
                break;
        }
    }

    public void SetIdleState()
    {
        stateController.ChangeState(stateController.idleState);
    }

    public void SetRunState()
    {
        stateController.ChangeState(stateController.runState);
    }

    public void SetRollState()
    {
        stateController.ChangeState(stateController.rollState);
    }

    public void SetJumpState()
    {
        stateController.ChangeState(stateController.jumpState);
    }

    public void SetAttackState()
    {
        stateController.ChangeState(stateController.attackState);
    }

    public void SetAttack2State()
    {
        stateController.ChangeState(stateController.attack2State);
    }

    public void SetCrouchState()
    {
        stateController.ChangeState(stateController.crouchState);
    }

    public void SetDeathState()
    {
        stateController.ChangeState(stateController.deathState);
    }
}
