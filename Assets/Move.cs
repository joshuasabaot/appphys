using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public CharacterController controller;
    public PlayerInput input;
    public Vector2 moveDir = Vector2.zero;
    public float movespeed;
    public Animator animator;


    private void Update()
    {
        var sideMovement = transform.right * moveDir.x;
        var forwardMovement = transform.forward *  moveDir.y;
        var movement = sideMovement + forwardMovement;
        controller.Move( movement * (movespeed * Time.deltaTime));
    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        var move = ctx.ReadValue<Vector2>();
        animator.SetBool("IsMoving", (move.x != 0 || move.y != 0));


        moveDir = new Vector2(move.x, move.y);
        animator.SetFloat("hMove", move.x);
        animator.SetFloat("vMove", move.y);
    }

    public void Ragdoll(InputAction.CallbackContext ctx)
    {
        animator.enabled = false;
    }
}
