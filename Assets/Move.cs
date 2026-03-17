using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public CharacterController controller;
    public Vector2 moveDir = Vector2.zero;
    public float movespeed;
    public float gravityValue = -9.81f;
    public Animator animator;

    Vector3 gravity;

    


    private void Update()
    {
        var sideMovement = transform.right * moveDir.x;
        var forwardMovement = transform.forward *  moveDir.y;
        var movement = sideMovement + forwardMovement;

        if (controller.isGrounded && gravity.y < 0)
        {
            gravity.y = -.03f;
        } else
        {
            gravity.y += gravityValue * Time.deltaTime;
        }
            


        controller.Move( (movement * (movespeed * Time.deltaTime)) + (gravity*Time.deltaTime));

    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        var move = ctx.ReadValue<Vector2>();
        if (animator)
        {
            animator.SetBool("IsMoving", (move.x != 0 || move.y != 0));
        }


        moveDir = new Vector2(move.x, move.y);
        if (animator)
        {
            animator.SetFloat("hMove", move.x);
            animator.SetFloat("vMove", move.y);
        }
        
    }

    public void Ragdoll(InputAction.CallbackContext ctx)
    {
        if (!animator) return;
        animator.enabled = false;
    }
}
