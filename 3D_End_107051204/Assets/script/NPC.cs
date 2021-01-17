
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCdeta deta;
    [Header("對話框")]
    public GameObject dialogue;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.2f;



    public bool playerInArea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "狗狗")
        {
            playerInArea = true;
           StartCoroutine (Dialogue());
            
           
        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name =="狗狗")
        {
            playerInArea = false;
            StopDialogue();
           
            
        }
        
    }
    private void StopDialogue()
    {
        dialogue.SetActive(false);
        StopAllCoroutines();
    }
    private IEnumerator Dialogue()
    {

        dialogue.SetActive(true);
        textContent.text = "";
        for (int i = 0; i < deta.dialogueA.Length; i++)
        {
            // print(deta.dialogueA[i]);
            textContent.text += deta.dialogueA[i] + "";        
            yield return new WaitForSeconds(interval);
        }
    }
    
        
    

    

   

			
}
