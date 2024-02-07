using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{

    #region variables
    [SerializeField] private GameObject achievementPrefab;
    [SerializeField] private AudioSource achievementSpeaker;

    private AchievementButton activeButton;
    public ScrollRect scrollRect;

    public GameObject achievementMenu;
    public GameObject visualAchievement;

    public static bool gameIsPaused = false;

    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

    public Sprite unlockedSprite;

    public Text textPoints;

    private static AchievementManager instance;

    private int fadeTime = 2;
    #endregion

    //Zorgt ervoor dat de achievement manager bestaat
    public static AchievementManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AchievementManager>();
            }

            return AchievementManager.instance;
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        //REMEMBER TO REMOVE
        PlayerPrefs.DeleteAll();

        activeButton = GameObject.Find("GeneralBtn").GetComponent<AchievementButton>();

        //Basic Achievements
        CreateAchievement("General", "Prestatie Ontgrendeld", "Welkom bij Bike Totaal", "Voltooi de intro van de game", 10);
        CreateAchievement("General", "Prestatie Ontgrendeld", "Level 1 behaald", "Haal 15 punten in level 1", 5);
        CreateAchievement("General", "Prestatie Ontgrendeld", "Level 2 behaald", "Haal 15 punten in level 2", 5);
        CreateAchievement("General", "Prestatie Ontgrendeld", "Level 3 behaald", "Haal 15 punten in level 3", 5);
        CreateAchievement("General", "Prestatie Ontgrendeld", "TestAchievement", "YAAAY hij werkt :D", 5);

        //Master Achievements
        CreateAchievement("Master", "Prestatie Ontgrendeld", "Meester van level 2", "Voltooi level 2 foutloos", 10);
        CreateAchievement("Master", "Prestatie Ontgrendeld", "Meester van level 3", "Voltooi level 3 foutloos", 10);
        

        foreach (GameObject achievmentList in GameObject.FindGameObjectsWithTag("AchievementList"))
        {
            achievmentList.SetActive(false);
        }

        activeButton.Click();

        achievementMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //opent het achievement menu en pauzeert de game
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            if (gameIsPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }

        //Dit zijn 2 test achievements
        if (Input.GetKeyDown(KeyCode.W))
        {
            EarnAchievement("Duw op W");
            PlaySound();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            EarnAchievement("Duw op S");
            PlaySound();
        }
    }

    //Speelt een geluid af als je een achievement behaald
    public void PlaySound()
    {
        achievementSpeaker.Play();
    }

    public void Resume()
    {
        achievementMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        achievementMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void EarnAchievement(string title)
    {
        if (achievements[title].EarnAchievement())
        {
            //DO SOMETHING AWESOME!
            GameObject achievement = (GameObject)Instantiate(visualAchievement);
            SetAchievementInfo("EarnCanvas", achievement, title);
            textPoints.text = "Punten: " + PlayerPrefs.GetInt("Points");
            StartCoroutine(FadeAchievement(achievement));
        }
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    public void CreateAchievement(string parent, string unlocked, string title, string description, int points, string[] dependencies = null)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);

        Achievement newAchievement = new Achievement(name, description, points, achievement);

        achievements.Add(title, newAchievement);

        SetAchievementInfo(parent, achievement, title);

        if (dependencies != null)
        {
            foreach (string achievementTitle in dependencies)
            {
                Achievement dependency = achievements[achievementTitle];
                dependency.Child = title;
                newAchievement.AddDependency(dependency);
            }
        }
    }

    public void SetAchievementInfo(string parent, GameObject achievement, string title)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);

        achievement.transform.GetChild(1).GetComponent<Text>().text = title;
        achievement.transform.GetChild(2).GetComponent<Text>().text = achievements[title].Description;
        achievement.transform.GetChild(3).GetComponent<Text>().text = achievements[title].Points.ToString();
    }

    public void ChangeCategory(GameObject button)
    {
        AchievementButton achievementButton = button.GetComponent<AchievementButton>();

        scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform>();

        achievementButton.Click();
        activeButton.Click();
        activeButton = achievementButton;

    }

    private IEnumerator FadeAchievement(GameObject achievement)
    {
        CanvasGroup canvasGroup = achievement.GetComponent<CanvasGroup>();

        float rate = 1.0f / fadeTime;

        int startAlpha = 0;
        int endAlpha = 1;

        for (int i = 0; i < 2; i++)
        {
            float progress = 0.0f;

            while (progress < 1.0f)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }
            yield return new WaitForSeconds(4);
            startAlpha = 1;
            endAlpha = 0;
        }

        Destroy(achievement);
    }
}
