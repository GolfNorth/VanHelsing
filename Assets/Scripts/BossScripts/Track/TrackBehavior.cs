using UnityEngine;


namespace BeastHunter
{
    public class TrackBehavior : MonoBehaviour
    {
        #region Fields

        private float _timer;
        private bool _isActive;
        private bool _isVisible;
        private MeshRenderer _mesh;

        #endregion


        #region Properties

        public float Timer => _timer;

        public bool IsActive => _isActive;

        public bool IsVisible => _isVisible;

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
        }

        private void Update()
        {
            _timer += Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            _isVisible = true;
            _mesh.enabled = true;
        }

        private void OnTriggerExit(Collider other)
        {
            _isVisible = false;
            _mesh.enabled = false;
        }

        #endregion
    }
}