using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public Player player;
    public float faidDurethion = 1;
    public float Delay = 1;
    public CanvasGroup exitPanel;
    public CanvasGroup caughtPanel;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;

    private bool isPlayerAtExit;
    private bool isPlayerCaught;
    private float timer;
    private bool hasAudioPlayed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            isPlayerAtExit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            isPlayerAtExit = false;
        }
    }
    private void Update()
    {
        if (isPlayerAtExit)
        {
            if (player.GetHasKeyValue())
            {
                EndLevel(exitPanel, false, exitAudio);
            }

            else
            {
                MessageController.Instance.SetMessageByType(MessageType.FindKey);
            }
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtPanel, true, caughtAudio);
        }
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (hasAudioPlayed == false)
        {
            hasAudioPlayed = true;
            audioSource.Play();
        }

        timer += Time.deltaTime;
        imageCanvasGroup.alpha = timer / faidDurethion;

        if (timer > faidDurethion)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                SceneManager.LoadScene(SceneType.Menu.ToString());
            }
        }
    }

    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }
}
