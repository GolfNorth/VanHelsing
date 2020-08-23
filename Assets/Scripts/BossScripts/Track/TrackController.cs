using System.Collections.Generic;


namespace BeastHunter
{
    public class TrackController : IUpdate
    {
        #region Fields

        private readonly GameContext _context;

        #endregion
        
        
        #region ClassLifeCycle

        public TrackController(GameContext context)
        {
            _context = context;
            _context.TrackModels = new Dictionary<int, TrackModel>();
        }

        #endregion


        #region IUpdate

        public void Updating()
        {
            foreach (var trackerModel in _context.TrackModels)
            {
                trackerModel.Value.Execute();
            }
        }

        #endregion
    }
}