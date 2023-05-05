using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float speedText;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComp.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (textComp.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // We are typing the each character one by one.
        foreach (char character in lines[index].ToCharArray())
        {
            textComp.text += character;
            yield return new WaitForSeconds(speedText);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            GameObject dialogueBoxImage = GameObject.Find("DialogueBoxImage");
            if (dialogueBoxImage != null)
            {
                Destroy(dialogueBoxImage);
            }
            gameObject.SetActive(false);
            TimeCheck timer = FindObjectOfType<TimeCheck>();
            if (timer != null)
            {
                timer.timeStart = 0;
                timer.DisplayTime();
            }
        }
    }


}
