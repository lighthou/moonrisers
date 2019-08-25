using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene("LeoScene");
    }
}