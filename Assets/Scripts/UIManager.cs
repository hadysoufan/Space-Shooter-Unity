using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _LivesImage;
    [SerializeField]
    private Sprite[] _liveSprites;


    // Start is called before the first frame update
    void Start()
    {
        
        _scoreText.text = "Score: " + 0;
    }

    public void UpdateScore(int playerScore){
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives){
        _LivesImage.sprite = _liveSprites[currentLives];
    }
}
