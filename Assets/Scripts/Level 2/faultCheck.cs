using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faultCheck : MonoBehaviour
{
    [SerializeField] private int boxNumber;
    [SerializeField] private scoreSO score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(boxNumber.ToString()))
        {
            Destroy(collision.gameObject);
            score.addScore(1);
        }
        else
        {
            Destroy(collision.gameObject);
            score.subtractScore(1);
        }
    }
}
