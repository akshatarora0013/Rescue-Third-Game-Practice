using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoints wayPoint;
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;

    void Awake() {
        label = GetComponent<TextMeshPro>();  
        label.enabled = false;
        // displayCoordinates();
        wayPoint = GetComponentInParent<WayPoints>();
    }

    void Update()
    {   
        // if(!Application.isPlaying){
        //     displayCoordinates();
        //     updateObjectName();
        //     label.enabled = true;
        // }
        colorCoordinates();
        ToggleLabel();
    }

    void ToggleLabel(){
        if(Input.GetKeyDown(KeyCode.C)){
            label.enabled = !label.IsActive();
        }
    }

    void colorCoordinates(){
        if(wayPoint.IsPlaceable){
            label.color = defaultColor;
        }
        else{
            label.color = blockedColor;
        }
    }

    // void displayCoordinates(){
    //     coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
    //     coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
    //     label.text = coordinates.x + "," + coordinates.y;
    // }

    void updateObjectName(){
        transform.parent.name = coordinates.ToString();
    }
}
