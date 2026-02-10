using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public CharacterController controller;
    public PlayerInput input;
    public Vector3 moveDir = Vector3.zero;
    public float movespeed;
    public Animator animator;


    private void Update()
    {
        controller.Move(moveDir * movespeed * Time.deltaTime);
    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        var move = ctx.ReadValue<Vector2>();
        animator.SetBool("IsMoving", (move.x != 0 || move.y != 0));


        moveDir = new Vector3(move.x, 0, move.y);
        animator.SetFloat("hMove", move.x);
        animator.SetFloat("vMove", move.y);
    }

    public void Ragdoll(InputAction.CallbackContext ctx)
    {
        animator.enabled = false;
    }
}
