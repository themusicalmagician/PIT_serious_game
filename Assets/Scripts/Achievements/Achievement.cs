using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement
{
    #region variables
    //Dit zijn de variables die de achievments hun waardes geven
    private string name;
    private string description;
    private int points;
    private bool unlocked;

    private GameObject achievementRef;

    //Lijst van de dependencies voor de achievements
    private List<Achievement> dependencies = new List<Achievement>();
    #endregion

    #region set values 
    public string Name
    {
        get => name;
        set => name = value;
    }
    public string Description
    {
        get => description;
        set => description = value;
    }
    public bool Unlocked
    {
        get => unlocked;
        set => unlocked = value;
    }
    public int Points
    {
        get => points;
        set => points = value;
    }

    private string child;

    public string Child 
    { 
        get => child; 
        set => child = value; 
    }
    #endregion

    //Dit laad de achievement in 
    public Achievement(string name, string description, int points, GameObject achievementRef)
    {
        this.Name = name;
        this.Description = description;
        this.Points = points;
        this.Unlocked = false;
        this.achievementRef = achievementRef;

        LoadAchievement();
    }

    //Dit voegt een value toe aan de lijst met dependencies
    public void AddDependency(Achievement dependency)
    {
        dependencies.Add(dependency);
    }

    //Dit is de functie die het mogelijk maakt om de achievement te behalen
    public bool EarnAchievement()
    {
        if (!Unlocked && !dependencies.Exists(x => x.unlocked == false))
        {
            achievementRef.GetComponent<Image>().sprite = AchievementManager.Instance.unlockedSprite;
            SaveAchievement(true);

            if(child != null)
            {
                AchievementManager.Instance.EarnAchievement(child);
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    //Deze functie zorgt ervoor dat de achievements opgeslagen worden
    public void SaveAchievement(bool value)
    {
        Unlocked = value;

        int tmpPoints = PlayerPrefs.GetInt("Points");

        PlayerPrefs.SetInt("Points", tmpPoints += points);
        
        PlayerPrefs.SetInt(name, value ? 1 : 0);

        PlayerPrefs.Save();
    }

    //Via deze code word het geregeld dat je behaalde punten en achievements worden geladen
    public void LoadAchievement()
    {
        unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;

        if (unlocked)
        {
            AchievementManager.Instance.textPoints.text = "Punten: " + PlayerPrefs.GetInt("Points");
            achievementRef.GetComponent<Image>().sprite = AchievementManager.Instance.unlockedSprite;

        }
    }
}
