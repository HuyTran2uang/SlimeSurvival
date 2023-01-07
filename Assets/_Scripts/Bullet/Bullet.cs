using UnityEngine;

public class Bullet : FixedMonoBehaviour
{
    public virtual void ChangeDirection(Vector3 direction)
    {
        IChangeDirection[] obs = GetComponentsInChildren<IChangeDirection>();
        foreach (var i in obs)
            i.ChangeDirection(direction);
    }
}
