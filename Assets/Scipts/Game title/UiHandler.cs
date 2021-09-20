using UnityEngine;
using RunnerApi;
using System;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class UiHandler : MonoBehaviour
{
    public GameObject blinkOwner;
    public float loadPeriod = 1f;
    private Blink blinkComponent;
    public AudioClip startclip;
    private AudioSource audioPlayer;
    private bool isActive;
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        isActive = blinkOwner.activeSelf;
        blinkComponent = blinkOwner.GetComponent<Blink>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.INSTANCE.IsGameOver && SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioPlayer.PlayOneShot(startclip);
                blinkComponent.BeginBlink(0.1f);
                StartCoroutine(StartGame());
            }
        }
        else if (GameManager.INSTANCE.IsGameOver && SceneManager.GetActiveScene().buildIndex > 0)
        {
            SetIfNotActive();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioPlayer.PlayOneShot(startclip);
                blinkComponent.BeginBlink(0.1f);
                StartCoroutine(RetartGame());
            }
        }

    }

    private void SetIfNotActive()
    {
        if (!isActive)
        {
            isActive = true;
            blinkOwner.SetActive(true);
        }
    }

    private IEnumerator RetartGame()
    {
        yield return new WaitForSeconds(loadPeriod);
        GameManager.RetartGame();
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(loadPeriod);
        GameManager.StartGame();
    }
}
