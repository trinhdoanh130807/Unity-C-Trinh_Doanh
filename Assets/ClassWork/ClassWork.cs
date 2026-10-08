using NUnit.Framework;
using Unity.InferenceEngine.Tokenization.Parsers.HuggingFace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance.Provider;

class Character
{
    private string nameCharacter;
    private int maxHP, hp, atk, def;
    public int MaxHP
    {
        get
        {
            return maxHP;
        }
    }
    public string username
    {
        get
        {
            return nameCharacter;
        }
    }
    public Character(string Name, int health, int attack, int defense)
    {
        nameCharacter = Name;
        maxHP = health;
        hp = health;
        def = defense;
        atk = attack;
    }
    public int curHP
    {
        get
        {
            return hp;
        }
    }
    public int atkPoint
    {
        get
        {
            return atk;
        }
    }
    public int defPoint
    {
        get
        {
            return def;
        }
    }
    public int Healing(int tem)
    {
        if (tem <= 0)
        {
            return 0;
        }
        else
        {
            if (hp + tem > maxHP)
            {
                int value = maxHP - hp;
                hp = maxHP;
                return value;
            }
            else
            {
                hp += tem;
                return tem;
            }
            
        }
    }
    public int TakeDamage(int tem, int defFlag)
    {   
        if (tem <= 0)
        {
            return 0;
        }
        int takenDamage = (defFlag == 1) ? Mathf.RoundToInt((float)(tem) * tem / (tem + defPoint)) : tem;
        hp = (hp >= takenDamage) ? hp - takenDamage : 0;
        return takenDamage;
    }
}

public class ClassWork : MonoBehaviour
{

    void BattleLoop(Character user1, Character user2)
    {
        int total = 1;
        int defFlag1 = 0, defFlag2 = 0;
        while (user1.curHP > 0 && user2.curHP > 0)
        {
            int turn = Random.Range(1, 4);
            if (turn == 1)
            {
                if (total % 2 == 1)
                {
                    int damage = Mathf.RoundToInt(Random.Range(0.8f, 1.2f) * user1.atkPoint);
                    Debug.Log($"Lượt {total} \n");
                    Debug.Log($"{user1.username} Máu còn lại: {user1.curHP}/{user1.MaxHP}");
                    Debug.Log($"{user1.username} chọn tấn công");
                    int takenDamage = user2.TakeDamage(damage, defFlag2);
                    Debug.Log($"Sát thương gây ra: {takenDamage}");
                    total++;
                    defFlag2 = 0;
                }
                else
                {
                    int damage = Mathf.RoundToInt(Random.Range(0.8f, 1.2f) * user2.atkPoint);
                    Debug.Log($"Lượt {total} \n");
                    Debug.Log($"{user2.username} Máu còn lại: {user2.curHP}/{user2.MaxHP}");
                    Debug.Log($"{user2.username} chọn tấn công");
                    int takenDamage = user1.TakeDamage(damage, defFlag1);
                    Debug.Log($"Sát thương gây ra: {takenDamage}");
                    total++;
                    defFlag1 = 0;
                }
            }
            else if (turn == 2)
            {
                if (total % 2 == 1)
                {
                    Debug.Log($"Lượt {total} \n");
                    Debug.Log($"{user1.username} Máu còn lại: {user1.curHP}/{user1.MaxHP}");
                    Debug.Log($"{user1.username} chọn phòng thủ");
                    defFlag1 = 1;
                    total++;
                }
                else
                {
                    Debug.Log($"Lượt {total} \n");
                    Debug.Log($"{user2.username} Máu còn lại: {user2.curHP}/{user2.MaxHP}");
                    Debug.Log($"{user2.username} chọn phòng thủ");
                    defFlag2 = 1;
                    total++;
                }
            }
            else if(turn == 3)
            {
                if (total % 2 == 1)
                {
                    Debug.Log($"Lượt {total} \n");
                    Debug.Log($"{user1.username} Máu còn lại: {user1.curHP}/{user1.MaxHP}");
                    Debug.Log($"{user1.username} chọn hồi máu");
                    int generation = Mathf.RoundToInt(Random.Range(0f, 0.1f) * user1.MaxHP);
                    int healingPoint = user1.Healing(generation);
                    Debug.Log($"{user1.username} đã hồi {healingPoint} máu");
                    total++;
                }
                else
                {
                    Debug.Log($"Lượt {total} \n");
                    Debug.Log($"{user2.username} Máu còn lại: {user2.curHP}/{user2.MaxHP}");
                    Debug.Log($"{user2.username} chọn hồi máu");
                    int generation = Mathf.RoundToInt(Random.Range(0f, 0.1f) * user2.MaxHP);
                    int healingPoint = user2.Healing(generation);
                    Debug.Log($"{user2.username} đã hồi {healingPoint} máu");
                    total++;
                }

            }
        }
    }
    void Start()
    {
        Character user1 = new Character("Player", 1000, 250, 100);
        Character user2 = new Character("Monster", 2000, 100, 200);
        BattleLoop(user1, user2);
        Debug.Log("Battle end");
        Debug.Log($"{user1.username} máu còn lại: {user1.curHP}/{user1.MaxHP}");
        Debug.Log($"{user2.username} máu còn lại: {user2.curHP}/{user2.MaxHP}");
        if (user1.curHP == 0)
        {
            Debug.Log($"{user2.username} Win");
        }
        else
        {
            Debug.Log($"{user1.username} Win");
        }
    }
}
