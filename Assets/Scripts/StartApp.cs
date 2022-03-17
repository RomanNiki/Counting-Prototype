using Player;
using Spawner;
using UnityEngine;

public class StartApp : MonoBehaviour
{
    [SerializeField] private DragObject _playerPrefab;
    [SerializeField] private FollowCamera _camera;
    [SerializeField] private SphereSpawner _spawner;
    private DragObject _player;
    
    private void Awake()
    {
        _player = FindObjectOfType<DragObject>();
    }

    private void Start()
    {
        _player ??= Instantiate(_playerPrefab);
        _spawner.Init();
        _camera.Init(_player.transform);
    }
}