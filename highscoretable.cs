using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highscoretable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreentrylist;
    private List<Transform> highscoreentrytransformlist;
    private void Awake()
    {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);

        /*highscoreentrylist = new List<HighscoreEntry>()
        {
            new HighscoreEntry{ score = 6549, name = "binaya"},
            new HighscoreEntry{ score = 53, name = "sangam"},
            new HighscoreEntry{ score = 3753, name = "bibek"},
            new HighscoreEntry{ score = 437, name = "anish"},
            new HighscoreEntry{ score = 87678, name = "prakash"},
            new HighscoreEntry{ score = 343, name = "joy"},
            new HighscoreEntry{ score = 423, name = "adarsh"},
            new HighscoreEntry{ score = 67867, name = "rohit"},
            new HighscoreEntry{ score = 7637, name = "jyoti"},
            new HighscoreEntry{ score = 7935, name = "akash"},
        };*/

        string jsonstring = PlayerPrefs.GetString("highscoreTable");
       Highscores highscores = JsonUtility.FromJson<Highscores>(jsonstring);

        // sort highscore table according to score
        for (int i=0; i<highscoreentrylist.Count; i++)
        {
            for (int j=i+1; j<highscoreentrylist.Count; j++)
            {
                   if (highscoreentrylist[j].score > highscoreentrylist[i].score)
                {
                    //swap
                    HighscoreEntry temp = highscoreentrylist[i];
                    highscoreentrylist[i] = highscoreentrylist[j];
                    highscoreentrylist[j] = temp;
                }
            }
        }

        highscoreentrytransformlist = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreentrylist)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreentrytransformlist);
        }
        /*
        Highscores highscores = new Highscores { highscoreentrylist = highscoreentrylist };
        string Json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable",Json);
        PlayerPrefs.Save();
       Debug.Log(PlayerPrefs.GetString("highscoreTable"));*/
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformlist)
    {
        float templateHeight = 37f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformlist.Count);
        entryTransform.gameObject.SetActive(true);
        //Converting rank to string
        int rank = transformlist.Count + 1;
        string rankstring;
        switch (rank)
        {
            default:
                rankstring = rank + "th"; break;
            case 1: rankstring = "1st"; break;
            case 2: rankstring = "2nd"; break;
            case 3: rankstring = "3rd"; break;
        }

        // finds and updates the highscore stats via script
        entryTransform.Find("Postext").GetComponent<Text>().text = rankstring;

        int score = highscoreEntry.score;

        entryTransform.Find("Scoretext").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;

        entryTransform.Find("Nametext").GetComponent<Text>().text = name;

        transformlist.Add(entryTransform);
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreentrylist;
    }

    // this class represents single HighscoreEntry
    [System.Serializable]
    private class HighscoreEntry
        {
        public int score;
        public string name;

        }
}

