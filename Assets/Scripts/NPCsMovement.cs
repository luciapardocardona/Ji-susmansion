using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsMovement : MonoBehaviour
{
    [SerializeField] List<GameObject> monsters;
    bool isLightOn = false;
    List<float> positions = new List<float> { -1f, -4f, -7f };
    float posY = 3f;
    float posZ = 0f;

    void MoveMonsters()
    {
        List<int> tmpMonsters = new List<int> { };

        foreach (var position in positions)
        {
            int index = Random.Range(0, monsters.Count);
            tmpMonsters.Add(index);
            var monster = monsters[index];
            monster.transform.Translate(position,posY,posZ);
            //monster.GetComponent<NPCsDialogSystem>
        }
    }
}
