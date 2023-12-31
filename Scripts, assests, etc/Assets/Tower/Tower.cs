using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    public bool CreateTower(Tower towerPrefab, Vector3 position){
        Bank bank = FindObjectOfType<Bank>();
        if(bank == null){
            return false;
        }
        if(bank.CurrentBalance >= cost){
            Instantiate(towerPrefab.gameObject, position, Quaternion.identity);
            bank.WithDraw(cost);
            return true;
        }
        return false;
    }
}
