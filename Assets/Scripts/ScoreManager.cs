using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private GameObject _button;
    public RectTransform canvasRect;
    public Vector2 spawnPosition;
    public static ScoreManager instance;
    private bool isCreated = false;

    private void Awake()
    {
        if (instance != null) Destroy(this);

        instance = this;
    }
    private void Update()
    {
        if (score == 4 && isCreated == false)
            {
                GameObject NewButton = Instantiate(_button, canvasRect);
                RectTransform rectTransform = NewButton.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = spawnPosition;
                isCreated = true;
            }
    }

    public void Metod(int x) 
    {
        score += x;
        _score.text = score.ToString();
    }
}
