using UnityEngine;

public class PetMovement : FixedMonoBehaviour
{
    [SerializeField] private Transform _pet;
    [SerializeField] private Transform _player;
    [SerializeField] private float _areaSensorPlayer;
    [SerializeField] private float _maxDistance;
    [SerializeField] private bool _isMoving;
    [SerializeField] private float _timeIdle;
    [SerializeField] private float _timer;
    [SerializeField] private Vector3 _targetPosition;

    public float MoveSpeed => Random.Range(PetManager.Instance.MoveSpeed * 0.9f, PetManager.Instance.MoveSpeed * 1.1f);

    private void SetTransformPlayer()
    {
        if (GameObject.FindWithTag("Player") == null) return;
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void OnMovement()
    {
        if ((_pet.position - _player.position).magnitude > _maxDistance)
        {
            this.FlashToDistance();
            return;
        }

        if ((_pet.position - _player.position).magnitude > _areaSensorPlayer)
            this.MoveToPlayer();
        else
            this.MoveRandom();
    }

    private void MoveToPlayer()
    {
        _pet.position = Vector2.MoveTowards(_pet.position, _player.position, MoveSpeed * Time.deltaTime);
    }

    private Vector3 RandomPos()
    {
        float x = Random.Range(_player.position.x - _areaSensorPlayer / 2, _player.position.x + _areaSensorPlayer / 2);
        float y = Random.Range(_player.position.y - _areaSensorPlayer / 2, _player.position.y + _areaSensorPlayer / 2);
        Vector3 ranPos = new Vector3(x, y, 0);
        return ranPos;
    }

    private void MoveRandom()
    {
        _pet.position = Vector2.MoveTowards(_pet.position, _targetPosition, MoveSpeed / 2 * Time.deltaTime);
    }

    private void FlashToDistance()
    {
        Vector3 direction = (_player.position - _pet.position).normalized;
        _pet.position += direction * _areaSensorPlayer * 1.3f;
    }

    protected override void LoadComponent()
    {
        _pet = transform.parent;
        _areaSensorPlayer = 1f;
        _maxDistance = 2f;
        _timeIdle = 2f;
    }

    private void Update()
    {
        if (_timer <= 0)
        {
            _timer = _timeIdle;
            _targetPosition = this.RandomPos();
        }
        _pet.localScale = _player.localScale;
    }

    private void FixedUpdate()
    {
        this.OnMovement();
        TimeManager.Instance.Timer(ref _timer);
    }

    private void OnEnable()
    {
        this.SetTransformPlayer();
    }
}
