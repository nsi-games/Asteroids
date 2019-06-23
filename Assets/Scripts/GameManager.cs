using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public int score = 0;

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
