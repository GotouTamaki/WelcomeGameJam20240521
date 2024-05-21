using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = ScoreManager.Instance.Score.ToString();
    }
}
