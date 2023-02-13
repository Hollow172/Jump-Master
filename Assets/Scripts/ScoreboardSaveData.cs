using System.Collections.Generic;
using System;

namespace Hollow172.Scoreboards
{
    [Serializable]
    public class ScoreboardSaveData
    {
        public List<ScoreboardEntryData> highscores = new List<ScoreboardEntryData>();
    }

}

//Here we show how we want to save our code
//It is a list of highscores