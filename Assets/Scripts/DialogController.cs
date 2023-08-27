using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogController : MonoBehaviour
{
    List<string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Animator dialogAnimator;
    int index;

    void Start()
    {
        sentences = new List<string>();

    }
    public void startDialog(Dialog dialog)
    {

        dialogAnimator.SetBool("isOpen", true);
        nameText.text = dialog.name;
        sentences.Clear();
        index = dialog.index;
        if (dialog.count < 4)
        {
            sentences.Add(dialog.sentences[0]);
        }
        else
        {
            if (index == 0) //second npc
            {
                dialog.lastChoice = Random.Range(0, dialog.sentences.Count);
                sentences.Add(dialog.sentences[dialog.lastChoice]);
            }
            else //main npc
            {
                dialog.lastChoice = Controller.secondTrigger.dialog.lastChoice;
                sentences.Add(dialog.sentences[dialog.lastChoice]);
            }
        }
        dialog.audioSource.clip = dialog.clips[dialog.lastChoice];
        dialog.sentences.RemoveAt(dialog.lastChoice);
        dialog.clips.RemoveAt(dialog.lastChoice);
        dialog.count++;
        StartCoroutine(StartSounds(sentences[0], dialog.audioSource));
    }
    public void displayNextSentence()
    {

        string cur = sentences[0];
        sentences.RemoveAt(0);
        StopAllCoroutines();
        StartCoroutine(TypeText(cur));




    }
    public void endDialog()
    {
        dialogAnimator.SetBool("isOpen", false);
        Debug.Log("End of conversation");
    }

    IEnumerator TypeText(string line)
    {
        dialogText.text = "";
        foreach (char c in line)
        {
            dialogText.text += c;
            yield return null;
        }

    }

    IEnumerator StartSounds(string line, AudioSource audioSource)
    {
        audioSource.Play();
        dialogText.text = "";
        foreach (char c in line)
        {
            dialogText.text += c;
        }
        yield return new WaitUntil(() => !audioSource.isPlaying);
        audioSource.Stop();
        if (index == 0)
            Controller.mainTrigger.triggerDialog();
        else
            Controller.secondTrigger.triggerDialog();
    }
}
