using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hollow172.Scoreboards
{
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 6; //Max amount of highscores
        [SerializeField] private Transform highscoresHolderTransform = null; //Used for a table for highscores
        [SerializeField] private GameObject scoreboardEntryObject = null; //One highscore
        //ScoreboardEntryData testEntrydata = new ScoreboardEntryData();

        //Add win entry
        private void Update()
        {
            AddWinEntry();
        }

        private string SavePath => $"{Application.persistentDataPath}/highscores.json"; //Getter for save path

        private void Start()
        {
            ScoreboardSaveData savedScores = GetSavedScores(); //getting saved scores from a file

            SaveScores(savedScores); //saving score
            
            UpdateUI(savedScores); //showing saved scores on a screen
        }

        /* testing purposes
        [ContextMenu("Add Text Entry")]
        public void AddTestEntry()
        {
            AddEntry(testEntrydata);
        }
        */

        //Collecting data of winning entry
        public void AddWinEntry()
        {
            if (Timer.isWon && (WinMenu.didPressApply || string.IsNullOrEmpty(WinMenu.ReadPlayerNick())))
            {
                ScoreboardEntryData winEntrydata = new ScoreboardEntryData();
                winEntrydata.entryName = WinMenu.ReadPlayerNick();
                if (string.IsNullOrEmpty(winEntrydata.entryName)) winEntrydata.entryName = "Anonymous";
                double minScoreboard = ((int)Timer.timeForScoreboard() / 60);
                double secScoreboard = (Timer.timeForScoreboard() % 60);
                winEntrydata.entryMinutes = minScoreboard;
                winEntrydata.entrySeconds = Math.Round(secScoreboard,1);
                AddEntry(winEntrydata);
                Timer.isWon = false;
            }
        }

        public void AddEntry(ScoreboardEntryData scoreboardEntryData)
        {
            ScoreboardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            //Adding score that is better than the rest of highscores
            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if(scoreboardEntryData.entryMinutes <= savedScores.highscores[i].entryMinutes)
                {
                    if (scoreboardEntryData.entrySeconds <= savedScores.highscores[i].entrySeconds)
                    {
                        savedScores.highscores.Insert(i, scoreboardEntryData);
                        scoreAdded = true;
                        break;
                    }
                }
            }

            //If score is worse and there is a place in list
            if(!scoreAdded && savedScores.highscores.Count < maxScoreboardEntries)
            {
                savedScores.highscores.Add(scoreboardEntryData);
            }

            //Removing if too much entries
            if(savedScores.highscores.Count > maxScoreboardEntries)
            {
                savedScores.highscores.RemoveRange(maxScoreboardEntries, savedScores.highscores.Count - maxScoreboardEntries);
            }

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        private void UpdateUI(ScoreboardSaveData savedScores)
        {
            //Destroying all children in highscore holder
            foreach(Transform child in highscoresHolderTransform)
            {
                Destroy(child.gameObject);
            }

            //looping through list we spawn scoreboard entry as a child of highscore holder
            foreach(ScoreboardEntryData highscore in savedScores.highscores)
            {
                Instantiate(scoreboardEntryObject, highscoresHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(highscore);
            }
        }

        private ScoreboardSaveData GetSavedScores()
        {
            //Creating empty list if file doesnt exist
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose(); 
                return new ScoreboardSaveData();
            }

            //Getting file that exists
            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd(); //Reading from file
                return JsonUtility.FromJson<ScoreboardSaveData>(json); //Converting to datatype we want - ScoreboardSaveData
            }
        }

        private void SaveScores(ScoreboardSaveData scoreboardSaveData)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreboardSaveData, true); //Converting 
                stream.Write(json); //Saving to file
            }
        }

        public void MainMenuButton()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}


