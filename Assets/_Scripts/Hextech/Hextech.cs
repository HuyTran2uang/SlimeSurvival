using UnityEngine;

public abstract class Hextech : FixedMonoBehaviour
{
    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField] public Sprite Sprite { get; protected set; }
    [field: SerializeField] public string Description { get; protected set; }

    public abstract void Use();
}
