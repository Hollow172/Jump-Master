using System;

namespace Hollow172.Scoreboards
{
    //Since it needs to be saved in a file Serializable is needed
    [Serializable] 
    public struct ScoreboardEntryData
    {
        public string entryName;
        public double entryMinutes;
        public double entrySeconds;
    }
}

/*

    Data that we want to save

 */