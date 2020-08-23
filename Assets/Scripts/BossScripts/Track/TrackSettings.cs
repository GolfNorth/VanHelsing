using System;
using UnityEngine;


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

        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _lifetime;
        [SerializeField] private float _countdown;
        [SerializeField] private float _activationRadius;
        [SerializeField] private Mesh _mesh;
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

        public float ActivationRadius
        {
            get => _activationRadius;
            set => _activationRadius = value;
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