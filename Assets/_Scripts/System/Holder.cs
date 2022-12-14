using UnityEngine;

public class Holder : MonoBehaviourSingleton<Holder>
{
    [SerializeField] private int _childCount;

    public void AddToChild(GameObject obj)
    {
        obj.transform.SetParent(transform);
        _childCount++;
    }
}
