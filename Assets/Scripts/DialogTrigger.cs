using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    DialogController dialogController;
    private void Start()
    {
        dialogController = FindFirstObjectByType<DialogController>();
    }
    public void triggerDialog()
    {
        Debug.Log("Triggered by: " + dialog.name + "current list: " + dialog.sentences.Count);
        if (dialog.sentences.Count > 0)
            dialogController.startDialog(dialog);
        else
            dialogController.endDialog();
    }
}
