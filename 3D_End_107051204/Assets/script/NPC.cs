
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCdeta deta;


    public bool playerInArea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "狗狗")
        {
            playerInArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name =="狗狗")
        {
            playerInArea = false;
        }
    }

    private void dialogue()
    {
        print(deta.dialogueA);
    }

}
