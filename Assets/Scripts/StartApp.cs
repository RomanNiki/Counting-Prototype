using Player;
using Player.UI;
using Spawner;
using UnityEngine;

public class StartApp : MonoBehaviour
{
    [SerializeField] private DragObject _playerPrefab;
    [SerializeField] private FollowCamera _camera;
    [SerializeField] private SphereSpawner _spawner;
    [SerializeField] private BallPointer _ballPointerPrefab;
    [SerializeField] private UIScoreMover _scoreMoverPrefab;
    private BallPointer _ballPointer;
    private DragObject _player;
    private UIScoreMover _scoreMover;

    private void Awake()
    {
        _player = FindObjectOfType<DragObject>();
        _ballPointer = FindObjectOfType<BallPointer>();
        _scoreMover = FindObjectOfType<UIScoreMover>();
    }

    private void OnEnable()
    {
        _player ??= Instantiate(_playerPrefab);
        _ballPointer ??= Instantiate(_ballPointerPrefab);
        _scoreMover ??= Instantiate(_scoreMoverPrefab);
        _spawner.Init();
        _ballPointer.Init(_spawner);
        _scoreMover.Init(_player);
        _camera.Init(_player.transform);
    }
}