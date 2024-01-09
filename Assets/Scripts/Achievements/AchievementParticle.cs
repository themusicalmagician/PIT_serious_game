using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem Left;
    [SerializeField] private ParticleSystem Right;

    public void Start()
    {
        Left.Play();
        Right.Play();
    }
}
