using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem Left;
    [SerializeField] private ParticleSystem Right;

    public void Awake()
    {
        Left = GameObject.Find("ParticleAchievementL").GetComponent<ParticleSystem>();
        Right = GameObject.Find("ParticleAchievementR").GetComponent<ParticleSystem>();

        Left.Play();
        Right.Play();
    }
}
