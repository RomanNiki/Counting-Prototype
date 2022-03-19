using Balls;
using Spawner;
using UnityEngine;
using UnityEngine.UI;

namespace Player.UI
{
    public class BallPointer : MonoBehaviour
    {
        [SerializeField] private RectTransform _pointerRectTransform;
        [SerializeField] private Image _pointerImage;
        [Range(0.5f, 0.9f)] [SerializeField] private float _screenBoundOffset = 0.9f;
        private Vector3 _screenCenter;
        private Vector3 _screenBounds;
        private SphereSpawner _spawner;
        private Camera _camera;
        private Transform _targetTransform;

        private void Awake()
        {
            _screenCenter = new Vector3(Screen.width, Screen.height, 0) / 2;
            _screenBounds = _screenCenter * _screenBoundOffset;
            _camera = Camera.main;
            Hide();
        }

        private void Update()
        {
            DrawIndicators();
        }

        private void OnDisable()
        {
            _spawner.CreatedBall -= Show;
        }
        
        private void DrawIndicators()
        {
            if (_pointerImage.enabled == false)
            {
                return;
            }

            var screenPosition = OffScreenIndicatorCore.GetScreenPosition(_camera, _targetTransform.position);
            var isTargetVisible = OffScreenIndicatorCore.IsTargetVisible(screenPosition);

            if (isTargetVisible)
            {
                screenPosition.z = 0;
                Hide();
            }
            else
            {
                var angle = float.MinValue;
                OffScreenIndicatorCore.GetArrowIndicatorPositionAndAngle(ref screenPosition, ref angle, _screenCenter, _screenBounds);
                _pointerRectTransform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
                _pointerRectTransform.position = screenPosition;
            }
        }
        
        private void Hide()
        {
            _pointerImage.enabled = false;
        }

        private void Show(Ball ball)
        {
            _targetTransform = ball.transform;
            _pointerImage.enabled = true;
        }

        public void Init(SphereSpawner spawner)
        {
            _spawner = spawner;
            spawner.CreatedBall += Show;
        }
    }
}