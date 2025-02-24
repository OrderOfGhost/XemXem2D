using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

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
                button.onClick.AddListener(() => stateController.ChangeStateByAction(btnAction.playerAction));
            }
        }
    }

    private void Update()
    {
        stateController.Update();
    }
}
