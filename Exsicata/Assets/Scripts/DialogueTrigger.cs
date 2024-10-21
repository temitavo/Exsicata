using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake(){

        playerInRange = false;
        visualCue.SetActive(false);
    }

    private void Update(){
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            visualCue.SetActive(true);
            
            if(PlayerInput.GetInstance().GetInteractPressed()){
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }else{
            visualCue.SetActive(false);
        }
        
        
    }

    private void OnTriggerEnter(Collider collider){
        if(collider.tag == "Player"){
            playerInRange = true;
            Debug.Log("Player in range.");
        }
    }

    private void OnTriggerExit(Collider collider){
        if(collider.tag == "Player"){
            playerInRange = false;
            Debug.Log("Player out of range.");
        }
    }
}
