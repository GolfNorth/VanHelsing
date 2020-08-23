using UnityEngine;


namespace BeastHunter
{
    public class TrackBehavior : MonoBehaviour
    {
        #region Fields

        private float _timer;
        private bool _isActive;
        private bool _isVisible;
        private bool _isFound;
        private MeshRenderer _mesh;
        private string _tracker;

        #endregion


        #region Properties

        public float Timer => _timer;

        public bool IsActive => _isActive;

        public bool IsFound => _isFound;

        public bool IsVisible
        {
            get => _isVisible;
            set => _isVisible = value;
        }

        public string Tracker
        {
            get => _tracker;
            set => _tracker = value;
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _mesh = GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
            _timer = 0;
            _isActive = true;
            _mesh.enabled = false;
        }

        private void OnDisable()
        {
            _isActive = false;
            _isFound = false;
        }

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_tracker))
            {
                _isFound = true;
                _mesh.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_tracker))
            {
                _isFound = false;
                _mesh.enabled = false;
            }
        }

        #endregion
    }
}