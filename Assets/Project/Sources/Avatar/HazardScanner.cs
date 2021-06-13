using UnityEngine;

namespace ReversePlatformer
{
    public class HazardScanner : MonoBehaviour
    {
        #region Public
        /// <summary>
        /// Raycasts forward and down to anticipate for obstacles ahead.
        /// </summary>
        /// <returns>A Hazard found close ahead.</returns>
        public Hazard ScanForHazardsAhead()
        {
            Vector3 shootDirection = new Vector3(1, -0.2f, 0);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, shootDirection, 4);
            Debug.DrawRay(transform.position, shootDirection * 4, Color.green);

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider != null)
                {
                    IJumpable jumpable = hit.collider.gameObject.GetComponent<IJumpable>();
                    if (jumpable != null)
                    {
                        (JumpableTypes jumpType, bool canBeJumped) = jumpable.onJumpableApproach();
                        Hazard hazardAhead = new Hazard(jumpType, canBeJumped, hit.collider.transform);
                        return hazardAhead;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}