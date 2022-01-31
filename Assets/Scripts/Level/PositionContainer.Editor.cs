#if UNITY_EDITOR
using UnityEngine;

namespace Asteroids.Level
{
    public partial class PositionsContainer
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            for (int i = 0; i < _positions.Count; i++)
            {
                if (_positions[i] != null)
                    Gizmos.DrawSphere(_positions[i].position, 0.2f);
            }
        }
    }
}
#endif
