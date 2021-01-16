
using UnityEngine;

[CreateAssetMenu(fileName ="NPC資料", menuName ="BETTY/NPC資料")]
public class NPCdeta :ScriptableObject
{
    [Header("第一段對話"), TextArea(1, 5)]
    public string dialogueA;
    [Header("第一段對話"), TextArea(1, 5)]
    public string dialogueB;
    [Header("第一段對話"), TextArea(1, 5)]
    public string dialogueC;
    [Header("任務項目需求數量")]
    public int count;
    [Header("已經取得項目數量")]
    public int countCurrent;
}
