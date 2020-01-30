using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamestatus : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int Points;
    [SerializeField] int Score = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] bool isAutoPlayEnabled;
    // Start is called before the first frame update

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<gamestatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }

    private void Start()
    {
        ScoreText.text = Score.ToString(); 
    }
    public void addPoints()
    {
        Score += Points;
        ScoreText.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        Time.timeScale = gameSpeed;

    }

    public void resetGame()
    {
        Destroy(gameObject);
        
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
