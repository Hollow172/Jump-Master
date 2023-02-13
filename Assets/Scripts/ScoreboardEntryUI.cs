using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Hollow172.Scoreboards
{
    public class ScoreboardEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryMinutesText = null;
        [SerializeField] private TextMeshProUGUI entrySecondsText = null;

        public void Initialise(ScoreboardEntryData scoreboardEntryData)
        {
            entryNameText.text = scoreboardEntryData.entryName;
            entryMinutesText.text = scoreboardEntryData.entryMinutes.ToString()+":";
            entrySecondsText.text = scoreboardEntryData.entrySeconds.ToString();
        }
    }
}

//Displaying text on screen

