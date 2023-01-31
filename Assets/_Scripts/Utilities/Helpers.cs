using UnityEngine;

public static class Helpers
{
    public static void DestroyChildren(this Transform t)
    {
        foreach (Transform child in t) Object.Destroy(child.gameObject);
    }

    public static void SetActiveChildren(this Transform t)
    {
        foreach (Transform child in t) child.gameObject.SetActive(false);
    }

    public static void Flip(Transform self, Transform mark)
    {
        if (self.position.x > mark.position.x)
            self.localScale = Vector3.one;
        if (self.position.x < mark.position.x)
            self.localScale = new Vector3(-1, 1, 1);
    }

    public static void Flip(Transform self, Vector2 direction)
    {
        if (direction.x > 0)
            self.localScale = Vector3.one;
        if (direction.x < 0)
            self.localScale = new Vector3(-1, 1, 1);
    }
}
