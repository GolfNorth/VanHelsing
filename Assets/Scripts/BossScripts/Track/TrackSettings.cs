using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace BeastHunter
{
    [Serializable]
    public class TrackSettings
    {
        #region PrivateData

        private enum Trackers
        {
            Player,
            Enemy,
            NPC
        }

        #endregion
        
        
        #region Fields

        [Tooltip("Track prefab")]
        [SerializeField] private GameObject _prefab;
        [Tooltip("Track lifetime")]
        [SerializeField] private float _lifetime;
        [Tooltip("Time between track spawn")]
        [SerializeField] private float _countdown;
        [Tooltip("Trace detection radius")]
        [SerializeField] private float _detectionRadius;
        [Tooltip("Time mesh")]
        [SerializeField] private Mesh _mesh;
        [Tooltip("Who can find traces")]
        [SerializeField] private Trackers _tracker;

        #endregion


        #region Properties

        public GameObject Prefab
        {
            get => _prefab;
            set => _prefab = value;
        }

        public float Lifetime
        {
            get => _lifetime;
            set => _lifetime = value;
        }

        public float Countdown
        {
            get => _countdown;
            set => _countdown = value;
        }

        public float DetectionRadius
        {
            get => _detectionRadius;
            set => _detectionRadius = value;
        }

        public Mesh Mesh
        {
            get => _mesh;
            set => _mesh = value;
        }

        public string Tracker
        {
            get
            {
                switch (_tracker)
                {
                    default:
                    case Trackers.Player:
                        return TagManager.PLAYER;
                        break;
                    case Trackers.Enemy:
                        return TagManager.ENEMY;
                        break;
                    case Trackers.NPC:
                        return TagManager.NPC;
                        break;
                }
            }
            set => _tracker = Enum.TryParse(value, out Trackers tracker) ? tracker : Trackers.Player;
        }

        #endregion
    }
}