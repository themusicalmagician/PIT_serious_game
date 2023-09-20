using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setup : MonoBehaviour
{
    [SerializeField] private scoreSO score;

    // Start is called before the first frame update
    void Start()
    {
        score.scoreSet();
    }
}
