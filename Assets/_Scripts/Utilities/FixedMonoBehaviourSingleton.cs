using UnityEngine;

public class FixedMonoBehaviourSingleton<T> : FixedMonoBehaviour where T : FixedMonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                var objs = FindObjectsOfType(typeof(T)) as T[];
                if (objs.Length > 0)
                    _instance = objs[0];
                if (objs.Length > 1)
                    Debug.LogError("There is more than one " + typeof(T).Name + " in the scene.");
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
}

public class FixedMonoBehaviourSingletonPersistent<T> : FixedMonoBehaviour where T : FixedMonoBehaviour
{
    public static T Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance == null)
        {
            Instance = this as T;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }
}
