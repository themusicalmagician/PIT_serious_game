using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{

    private string name;
    private string description;
    private bool unlocked;

    private GameObject achievementRef;



    public Achievement(string name, string description, GameObject achievementRef)
    {
        this.Name = name;
        this.Description = description;
        this.Unlocked = false;
        this.achievementRef = achievementRef;
    }

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


    public bool EarnAchievement()
    {
        if (!Unlocked)
        {
            Unlocked = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
