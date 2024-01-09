using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AchievementParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem Left;
    [SerializeField] private ParticleSystem Right;

    public void Awake()
    {
        Left = GameObject.FindWithTag("ParticleL").GetComponent<ParticleSystem>();
        Right = GameObject.FindWithTag("ParticleR").GetComponent<ParticleSystem>();

        Left.Play();
        
        Right.Play();
    }
}
