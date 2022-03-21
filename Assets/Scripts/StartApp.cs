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
        TryFindMainObjects();
        TryCreateObjects();
        InitializeClasses();
    }

    private void OnEnable()
    {
        _spawner.CreatedBall += _ballPointer.OnBallCreated;
    }

    private void OnDisable()
    {
        _spawner.CreatedBall -= _ballPointer.OnBallCreated;
    }

    private void TryCreateObjects()
    {
        _player ??= Instantiate(_playerPrefab);
        _ballPointer ??= Instantiate(_ballPointerPrefab);
        _scoreMover ??= Instantiate(_scoreMoverPrefab);
    }
    
    private void TryFindMainObjects()
    {
        _player = FindObjectOfType<DragObject>();
        _ballPointer = FindObjectOfType<BallPointer>();
        _scoreMover = FindObjectOfType<UIScoreMover>();
    }

    private void InitializeClasses()
    {
        _spawner.Init();
        _ballPointer.Init();
        var playerTransform = _player.transform;
        _scoreMover.Init(playerTransform);
        _camera.Init(playerTransform);
    }
    
}