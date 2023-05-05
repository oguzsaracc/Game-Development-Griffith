using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public TimeCheck timeCheck;
    public DialogueScript dialogueScript;
    public AudioClip finishAudioClip;

    private bool hasPlayerFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayerFinished)
        {
            hasPlayerFinished = true;

            // Check if the dialogue is active before stopping time
            if (!dialogueScript.isActiveAndEnabled)
            {
                timeCheck.StopTime();
            }

            timeCheck.DisplayTime();

            // Play the finish audio clip
            AudioSource.PlayClipAtPoint(finishAudioClip, transform.position);
        }
    }
}