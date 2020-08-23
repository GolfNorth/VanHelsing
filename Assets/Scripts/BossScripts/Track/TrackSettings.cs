using System;
using UnityEngine;


namespace BeastHunter
{
    [Serializable]
    public class TrackSettings
    {
        #region Fields

        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _lifetime;
        [SerializeField] private float _countdown;
        [SerializeField] private float _activationRadius;

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

        #endregion
    }
}