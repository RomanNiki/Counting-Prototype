using Player;
using Player.UI;
using Spawner;
using UnityEngine;

public class StartApp : MonoBehaviour
{
    [SerializeField] private DragObject _playerPrefab;
    [SerializeField] private FollowCamera _camera;
    [SerializeField] private SphereSpawner _spawner;
    [SerializeField] private BallPointer _arrowToBallPrefab;
    private BallPointer _arrowToBallPointer;
    private DragObject _player;

    private void Awake()
    {
        _player = FindObjectOfType<DragObject>();
        _arrowToBallPointer = FindObjectOfType<BallPointer>();
    }

    private void Start()
    {
        _player ??= Instantiate(_playerPrefab);
        _arrowToBallPointer ??= Instantiate(_arrowToBallPrefab);
        _spawner.Init();
        _arrowToBallPointer.Init(_spawner);
        _camera.Init(_player.transform);
    }
}