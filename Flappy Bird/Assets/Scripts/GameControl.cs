using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static GameControl instance; // Here we are using the Singleton pattern
    public TMP_Text scoreText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject mainMenuButton;
    public bool gameOver = false;
    public float scrollingSpeed = -1.5f;
    public AudioClip hitSound;
    public AudioClip pointSound;
    public AudioClip gameStartSound;
    public AudioClip flapSound;
    AudioSource audioSource;
    private int score = 0;
    private bool isHit = false; // to play hit sound only once
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if(instance != null) 
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        scoreText.enabled = true;
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BirdDied()
    {
        scoreText.enabled = false;
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
        gameOver = true;
        if(isHit == false)
        {
            PlaySound(hitSound);
        }
        isHit = true;
    }
    public void RestartGame()
    {
        PlaySound(gameStartSound);
        DontDestroyObjects();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void DontDestroyObjects()
    {
        DontDestroyOnLoad(scoreText);
        DontDestroyOnLoad(gameOverText);
        DontDestroyOnLoad(restartButton);
        DontDestroyOnLoad(gameStartSound);
    }
    public void BirdScored()
    {
        if(!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
            PlaySound(pointSound);
        }
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
