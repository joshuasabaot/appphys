using UnityEngine;

public class RagdollOnClick : MonoBehaviour
{
    Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        gameObject.tag = "Target";
    }
    public void Ragdoll()
    {
        _animator.enabled = false;
    }

}
