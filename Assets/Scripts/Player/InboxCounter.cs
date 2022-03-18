using System.Collections.Generic;
using Balls;
using Interfaces;
using Pool.NightPool;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class InboxCounter : MonoBehaviour, ICounter
    {
        private const int MaxBallCount = 100;
        [SerializeField] private int _startCombo = 20;
        [SerializeField] private int _comboComplication = 5;
        [SerializeField] private float _timeToClearBox;
        [SerializeField] private UnityEvent<int> _updatedScoreEvent;
        [SerializeField] private ParticleSystem _explosions;
        private int _score;
        private List<Ball> _balls;
        
        public event UnityAction<int> UpdatedScoreEvent
        {
            add => _updatedScoreEvent.AddListener(value);
            remove => _updatedScoreEvent.RemoveListener(value);
        }
        public static InboxCounter Instance { get; private set;}
        
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            _balls = new List<Ball>(MaxBallCount);
        }

        private void ComboClearBox()
        {   
            var count = _balls.Count;
            if (count < _startCombo) return;
            var explosion = NightPool.Spawn(_explosions);
            explosion.transform.position = transform.position;
            _balls.ForEach(x => NightPool.Despawn(x));
            _balls.RemoveAll(x=>x);

            if (_startCombo < MaxBallCount)
            {
                _startCombo += _comboComplication;
            }
        }

        public void AddBallInBox(Ball ball)
        {
            _score += ball.ScorePoints;
            _balls.Add(ball);
            _updatedScoreEvent.Invoke(_score);
            Invoke(nameof(ComboClearBox), _timeToClearBox);
        }

        public void RemoveBallFromBox(Ball ball)
        {
            _score -= ball.ScorePoints;
            _updatedScoreEvent.Invoke(_score);
            _balls.Remove(ball);
        }
    }
    
}