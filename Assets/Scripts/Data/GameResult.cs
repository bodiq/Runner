using System;
using System.Collections.Generic;

namespace Data
{
    [Serializable]
    public struct GameResult
    {
        public int gameCount;
        public int gameScore;
    }

    [Serializable]
    public class GameResults
    {
        public List<GameResult> results = new();
    }
}