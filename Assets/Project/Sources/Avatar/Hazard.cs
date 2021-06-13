using UnityEngine;

namespace ReversePlatformer
{ 
    /// <summary>
    /// Object representing the internal model of an obstacle coming ahead
    /// Used by the Avatar to aid in decision making.
    /// </summary>
    public class Hazard
    {
        public Hazard(JumpableTypes jumpType, bool jumpable, Transform hazardTransform)
        {
            _requiredJumpType = jumpType;
            _canBeJumped = jumpable;
            _hazardTransform = hazardTransform;
        }

        JumpableTypes _requiredJumpType;
        bool _canBeJumped;
        Transform _hazardTransform;
    }
}
