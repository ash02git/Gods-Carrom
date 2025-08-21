using UnityEngine;
using System;
using System.Collections.Generic;

namespace GodsCarrom.Hole
{
    [Serializable]
    public struct HoleData
    {
        public HoleView holePrefab;
        public List<Vector2> holePositions;
    }
}