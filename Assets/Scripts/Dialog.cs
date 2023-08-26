using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Dialog 
{
    public List<string> sentences;
    public List<AudioClip> clips; 
    public string name;
    public int index;
    public int count=0;
    public int lastChoice = 0;
    public AudioSource audioSource;
}
