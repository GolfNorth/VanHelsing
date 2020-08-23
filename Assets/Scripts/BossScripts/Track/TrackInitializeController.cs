using UnityEngine;


namespace BeastHunter
{
    public class TrackInitializeController : IAwake, ITearDown
    {
        #region Fields

        private readonly GameContext _context;
        private readonly TrackData _trackData;
        private readonly Transform _owner;
        private GameObject _holder;

        #endregion

        
        #region ClassLifeCycle

        public TrackInitializeController(GameContext context, TrackData trackData, Transform owner)
        {
            _context = context;
            _trackData = trackData;
            _owner = owner;
        }

        #endregion


        #region IAwake

        public void OnAwake()
        {
            _holder = new GameObject { name = _owner.name + "_tracks" };

            var trackerModel = new TrackModel(_trackData, _owner, _holder.transform);
            
            _context.TrackerModels.Add(_holder.GetInstanceID(), trackerModel);
        }

        #endregion


        #region ITearDown

        public void TearDown()
        {
            _context.TrackerModels.Remove(_holder.GetInstanceID());
            GameObject.Destroy(_holder);
        }

        #endregion
    }
}