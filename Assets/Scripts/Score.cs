using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    private int _score;
    [SerializeField] private TMP_Text _scoreView; 
    public void AddScore(int addedValue)
    {
        _score += addedValue;
        UpdateScoreView();
    }
    private void UpdateScoreView()
    {
        _scoreView.text ="Score: " + _score.ToString();
    }
}
