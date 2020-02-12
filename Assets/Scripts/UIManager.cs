﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Text _gameOverText;
    private bool _isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLives(int currentLives)
    {
        // display image sprite
        // give it a new one based on the currentLives index.
        _livesImage.sprite = _liveSprites[currentLives];
    }

    public void GameOver()
    {
        _gameOverText.gameObject.SetActive(true);
        _isGameOver = true;
        StartCoroutine("GameOverFlickerControl");
        
    }

    IEnumerator GameOverFlickerControl()
    {
        bool textOn = true;
        while (_isGameOver == true)
        {
            _gameOverText.gameObject.SetActive(textOn);
            textOn = !textOn;
            yield return new WaitForSeconds(1);
        }
    }
}
