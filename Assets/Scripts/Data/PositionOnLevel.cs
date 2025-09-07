using System;

namespace Scripts.Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public string Level;

        public PositionOnLevel(string level)
        {
            Level = level;
        }
    }
}