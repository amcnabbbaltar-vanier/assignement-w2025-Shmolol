using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private CharacterMovement characterMovement;

    public void Start()
    {
        animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
    }

    public void LateUpdate()
    {
        UpdateAnimator();
    }

    // TODO Fill this in with your animator calls
    void UpdateAnimator()
    {
        animator.SetFloat("CharacterSpeed", characterMovement.rb.velocity.magnitude);
        animator.SetBool("IsGrounded", characterMovement.IsGrounded);
        animator.SetBool("CanDoubleJump", characterMovement.canDoubleJump);

        if (characterMovement.jumpRequest && !characterMovement.IsGrounded && characterMovement.canDoubleJump)
        {
            animator.SetTrigger("doFlip");
        }
    }
}
