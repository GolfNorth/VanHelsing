using System.Collections.Generic;
using UnityEngine;


namespace BeastHunter
{
    public sealed class TrackModel
    {
        #region Fields
        
        private readonly TrackData _trackData;
        private readonly GameObject _prefab;
        private readonly Transform _owner;
        private readonly Transform _holder;
        private readonly Queue<TrackBehavior> _inactiveBehaviors;
        private readonly HashSet<TrackBehavior> _behaviorPool;
        private Vector3 _lastOwnerPosition;
        private float _countdown;
        private bool _isVisible;
        private bool _isFly;

        #endregion
        

        #region Properties

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                if (_isVisible != value)
                {
                    foreach (var behavior in _behaviorPool)
                    {
                        behavior.IsVisible = value;
                    }

                    _isVisible = value;
                }
            }
        }

        public bool IsFly
        {
            get => _isFly;
            set => _isFly = value;
        }

        #endregion
        
        
        #region ClassLifeCycle

        public TrackModel(TrackData trackData, Transform owner, Transform holder)
        {
            _trackData = trackData;
            _prefab = _trackData.TrackSettings.Prefab;
            _owner = owner;
            _holder = holder;
            _countdown = _trackData.TrackSettings.Countdown;
            _inactiveBehaviors = new Queue<TrackBehavior>();
            _behaviorPool = new HashSet<TrackBehavior>();
            _lastOwnerPosition = Vector3.zero;
        }

        #endregion
        
        
        #region Metods

        public void Execute()
        {
            if (!_isFly)
            {
                _countdown -= Time.deltaTime;

                if (_countdown <= 0)
                {
                    if (_lastOwnerPosition != _owner.position)
                    {
                        SpawnTracker(_prefab, _owner.position, _owner.rotation, _holder);
                    }

                    _countdown = _trackData.TrackSettings.Countdown;
                    _lastOwnerPosition = _owner.position;
                }

                foreach (var behavior in _behaviorPool)
                {
                    if (behavior.IsActive && behavior.Timer > _trackData.TrackSettings.Lifetime)
                    {
                        DeactivateTracker(behavior);
                    }
                }
            }
        }
        
        private GameObject SpawnTracker(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
        {
            GameObject gameObject;
            
            if (_inactiveBehaviors.Count == 0)
            {
                gameObject = GameObject.Instantiate(prefab, position, rotation, parent);
                var collider = gameObject.AddComponent<SphereCollider>();
                collider.radius = _trackData.TrackSettings.DetectionRadius;
                collider.isTrigger = true;
                var behavior = gameObject.AddComponent<TrackBehavior>();
                behavior.Tracker = _trackData.TrackSettings.Tracker;
                behavior.IsVisible = _isVisible;
                _behaviorPool.Add(behavior);
            }
            else
            {
                gameObject = _inactiveBehaviors.Dequeue().gameObject;
                gameObject.SetActive(true);
                gameObject.transform.position = position;
                gameObject.transform.rotation = rotation;
            }

            return gameObject;
        }

        private void DeactivateTracker(TrackBehavior behavior)
        {
            behavior.gameObject.SetActive(false);
            _inactiveBehaviors.Enqueue(behavior);
        }

        #endregion
    }
}