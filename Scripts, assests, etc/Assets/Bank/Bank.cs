using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI DisplayBalance;
    public int CurrentBalance{get{return currentBalance;}}

    void Awake(){
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount){
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }
    public void WithDraw(int amount){
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        if(currentBalance < 0){
            ReloadLevel();
        }
    }

    void UpdateDisplay(){
        DisplayBalance.text = "Gold: " + currentBalance;
    }

    void ReloadLevel(){
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

}
