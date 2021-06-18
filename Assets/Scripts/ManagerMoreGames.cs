using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMoreGames : MonoBehaviour {
    [Header("Add Games Buttons Here")]
    [Tooltip("The Total Number Of Buttons Should Be Multiple Of 5.")]
    public List<GameObject> ButtonsGames;
    [Header("Select Change Time")]
    [Range(0, 10)]
    [Tooltip("Seconds After Which New Buttons Appear.")]
    public float ChangeTime;
    
    float timer;
    bool Change;
    // Use this for initialization
    void Start () {
        timer = ChangeTime;
        Change = true;
	}

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (Change)
            {
                for (int i = 0; i < (ButtonsGames.Count/2); i++)
                {
                    ButtonsGames[i].SetActive(true);
                }
                for (int i = (ButtonsGames.Count / 2); i < ButtonsGames.Count; i++)
                {
                    ButtonsGames[i].SetActive(false);
                }
                Change = false;
            }
            else if (!Change)
            {
                for (int i = 0; i < (ButtonsGames.Count / 2); i++)
                {
                    ButtonsGames[i].SetActive(false);
                }
                for (int i = (ButtonsGames.Count / 2); i < 10; i++)
                {
                    ButtonsGames[i].SetActive(true);
                }
                Change = true;
            }

            timer = ChangeTime;
        }
    }
    public void FunctionButtonGame(string URL)
    {
        Application.OpenURL(URL);
    }
}
