using UnityEngine;

public class FixedMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        LoadComponent();
    }

    protected virtual void Reset()
    {
        LoadComponent();
    }

    protected virtual void LoadComponent()
    {
        //for override
    }
}
