using UnityEngine;


namespace BeastHunter
{
    [CreateAssetMenu(fileName = "TrackData")]
    public class TrackData : ScriptableObject
    {
        #region Fields
        
        [SerializeField] private TrackSettings _trackSettings;

        #endregion


        #region Properties

        public TrackSettings TrackSettings
        {
            get => _trackSettings;
            set => _trackSettings = value;
        }

        #endregion
    }
}