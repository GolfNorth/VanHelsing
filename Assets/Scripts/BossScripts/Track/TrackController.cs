using System.Collections.Generic;


namespace BeastHunter
{
    public class TrackController : IAwake, IUpdate
    {
        #region Fields

        private readonly GameContext _context;

        #endregion
        
        
        #region ClassLifeCycle

        public TrackController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region IAwake

        public void OnAwake()
        {
            _context.TrackerModels = new Dictionary<int, TrackModel>();
        }

        #endregion


        #region IUpdate

        public void Updating()
        {
            foreach (var trackerModel in _context.TrackerModels)
            {
                trackerModel.Value.Execute();
            }
        }

        #endregion
    }
}