using System.Collections;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [Header("Yêu cầu 1, 2, 3: Chỉ số cơ bản")]
    public string characterName="sas";
    public int maxHealth = 100;
    public int currentHealth=50;
    public int defense = 5;

    [Header("Cài đặt chiến đấu")]
    public float attackSpeed = 1.5f; 
    public CharacterCombat target;   
    private Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        
        Debug.Log("=== THÔNG TIN NHÂN VẬT ===");
        Debug.Log("1. Tên nhân vật: " + characterName);
        Debug.Log("2. Máu nhân vật: " + maxHealth);
        Debug.Log($"3. Chỉ số - Phòng thủ: {defense} | Tốc độ đánh: {attackSpeed}s");

        StartCoroutine(CombatLoop());
    }

    IEnumerator CombatLoop()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 1; i <= 10; i++)
        {
            if (currentHealth <= 0 || target == null || target.currentHealth <= 0)
            {
                break;
            }

            if (anim != null) anim.SetTrigger("Attack");

            int randomDamage = Random.Range(11, 20);
            
            Debug.Log($"--- HIỆP {i} ---");
            target.TakeDamage(randomDamage);

            yield return new WaitForSeconds(attackSpeed);
        }
    }

    public void TakeDamage(int incomingDamage)
    {
        int actualDamage = Mathf.Max(incomingDamage - defense, 1);
        
        currentHealth -= actualDamage;
        if (currentHealth < 0) currentHealth = 0;

        Debug.Log($"{characterName} bị chém mất {actualDamage} máu! Máu hiện tại: {currentHealth}");

        CheckHealthStatus();

        if (currentHealth <= 0)
        {
            Debug.Log($"---> {characterName} ĐÃ BỊ HẠ GỤC! <---");
        }
    }

    void CheckHealthStatus()
    {
        if (currentHealth < 20)
        {
            Debug.Log($"Yếu");
        }
        else if (currentHealth >= 20 && currentHealth <= 50)
        {
            Debug.Log($"Trung bình");
        }
        else if (currentHealth > 50)
        {
            Debug.Log($"Tốt");
        }
    }
}