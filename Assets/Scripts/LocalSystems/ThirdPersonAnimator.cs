using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Animator))]
public class ThirdPersonAnimator : MonoBehaviour{

    private Animator animator;
    private int animIDSpeed;
    private int animIDGrounded;
    private int animIDJump;
    private int animIDTurnAmount;
    private float runFactor;
    private float forwardVelocity;
    public float ForwardVelocity => forwardVelocity;
    private ThirdPersonController controller;

    private void Start() {
        AssignAnimationIDs();
        animator = GetComponent<Animator>();
        controller= GetComponent<ThirdPersonController>();
        animator.applyRootMotion= true;
    }

    private void AssignAnimationIDs() {
        animIDSpeed = Animator.StringToHash("Speed");
        animIDGrounded = Animator.StringToHash("Grounded");
        animIDJump = Animator.StringToHash("Jump");
        animIDTurnAmount = Animator.StringToHash("TurnAmount");
    }

    private void Update() {
        runFactor = Mathf.Lerp(runFactor, controller.Input.Sprint?2:1,Time.deltaTime*5);
        forwardVelocity = controller.Speed * runFactor;
        UpdateAnimator();
    }

    private void UpdateAnimator() {
        animator.SetFloat(animIDSpeed, controller.Speed * runFactor, 0.05f, Time.deltaTime);
        animator.SetFloat(animIDTurnAmount, controller.TurnAmount /100, 0.1f, Time.deltaTime);
        animator.SetBool(animIDGrounded, controller.Grounded);
        if (controller.Grounded && controller.Input.Jump) {
            animator.SetTrigger(animIDJump);
        }
    }
}
