using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Level
{
    public partial class PositionsContainer : MonoBehaviour
    {
        [SerializeField]
        private List<Transform> _positions;
        public IReadOnlyList<Transform> Positions => _positions;
    
        public Vector3 GetRandomPosition()
        {
            int positionIndex = Random.Range(0, _positions.Count - 1);
            return _positions[positionIndex].position;
        }
    }
}

