using UnityEngine;

namespace Player.UI
{
    [RequireComponent(typeof(Light))]
    public class DropPositionPointer : MonoBehaviour
    {
        [SerializeField] private float _lifeTime;
        private Light _light;
        private Transform _transform;

        private void Start()
        {
            _light = GetComponent<Light>();
            _transform = transform;
        }

        public void SetZPosition(float z)
        {
            var position = _transform.position;
            position.z = z;
            _transform.position = position;
            _light.enabled = true;
            Invoke(nameof(Deactivate), _lifeTime);
        }

        private void Deactivate()
        {
            _light.enabled = false;
        }
    }
}
