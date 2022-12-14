using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnMoveState()
    {
        _animator.SetBool("isMoving", true);
    }

    public void OnIdleState()
    {
        _animator.SetBool("isMoving", false);
    }
}
