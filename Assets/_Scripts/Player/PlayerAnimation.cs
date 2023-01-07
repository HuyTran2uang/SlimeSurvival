using UnityEngine;

public class PlayerAnimation : FixedMonoBehaviour
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

    protected override void LoadComponent()
    {
        _animator = transform.parent.transform.Find("Model").transform.GetChild(0).GetComponent<Animator>();
    }
}
