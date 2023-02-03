using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        _prefab = SkinManager.Instance.GetSkinUsing().Prefab;
        GameObject slime = Instantiate(_prefab, Vector3.zero, Quaternion.identity);
        Player player = slime.GetComponent<Player>();
        player.Special();
        GameManager.Instance.SetupBattle();
    }
}
