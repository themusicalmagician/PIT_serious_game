using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    public AchievementManager am;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TestAchievement", 5f);
    }


    void TestAchievement()
    {
        am.EarnAchievement("TestAchievement");
        am.PlaySound();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
