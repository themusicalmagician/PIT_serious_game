using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private GameObject achievementPrefab;


    // Start is called before the first frame update
    void Start()
    {
        CreateAchievement("General", "Prestatie ontgrendeld", "Test titel", "Dit is de beschrijving");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateAchievement(string category, string unlocked, string title, string description)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);
        SetAchievementInfo(category, achievement, unlocked, title, description);
    }

    public void SetAchievementInfo(string category, GameObject achievement, string unlocked, string title, string description)
    {
        achievement.transform.SetParent(GameObject.Find(category).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);

        achievement.transform.GetChild(0).GetComponent<Text>().text = unlocked;
        achievement.transform.GetChild(1).GetComponent<Text>().text = title;
        achievement.transform.GetChild(2).GetComponent<Text>().text = description;
    }
}
