using UnityEngine;

public class HomeworkStats : MonoBehaviour
{
    // YÊU CẦU 1: Thông tin tên nhân vật
    public string characterName = "ZiLong";

    // YÊU CẦU 2: Máu nhân vật
    public int maxHealth = 100;
    private int currentHealth;

    // YÊU CẦU 3: Bộ chỉ số bất kỳ
    public int attackDamage = 45;
    public int defense = 15;
    public float movementSpeed = 5.5f;

    void Start()
    {
        currentHealth = maxHealth;

        // In ra Console thông tin yêu cầu 1, 2, 3
        Debug.Log("=== THÔNG TIN NHÂN VẬT ===");
        Debug.Log("1. Tên nhân vật: " + characterName);
        Debug.Log("2. Máu nhân vật: " + maxHealth);
        Debug.Log($"3. Chỉ số - Công: {attackDamage} | Thủ: {defense} | Tốc độ: {movementSpeed}");
        Debug.Log("==========================");

        // Chạy hàm yêu cầu 5 (bên trong hàm này sẽ gọi luôn hàm yêu cầu 4)
        TakeRandomDamageLoop();
    }

    // YÊU CẦU 4: Hàm if-else kiểm tra mức độ máu
    void CheckHealthStatus()
    {
        if (currentHealth < 20)
        {
            Debug.Log($"[Trạng thái] Máu ({currentHealth}): Yếu");
        }
        else if (currentHealth >= 20 && currentHealth <= 50)
        {
            Debug.Log($"[Trạng thái] Máu ({currentHealth}): Trung bình");
        }
        else if (currentHealth > 50)
        {
            Debug.Log($"[Trạng thái] Máu ({currentHealth}): Tốt");
        }
    }

    // YÊU CẦU 5: Hàm for chạy lặp trừ đi máu của nhân vật 10 lần ngẫu nhiên
    void TakeRandomDamageLoop()
    {
        Debug.Log("=== BẮT ĐẦU TRỪ MÁU NGẪU NHIÊN 10 LẦN ===");
        
        for (int i = 1; i <= 10; i++)
        {
            // Random một lượng sát thương ngẫu nhiên từ 5 đến 15
            int randomDamage = Random.Range(5, 16); 
            
            // Trừ máu
            currentHealth -= randomDamage;
            
            // Đảm bảo máu không bị âm
            if (currentHealth < 0) currentHealth = 0;

            Debug.Log($"Lần {i}: Bị trừ {randomDamage} máu. Máu còn lại: {currentHealth}");

            // Gọi yêu cầu 4 để in ra mức độ máu hiện tại sau khi bị trừ
            CheckHealthStatus();

            // Nếu máu về 0 thì dừng vòng lặp sớm
            if (currentHealth <= 0)
            {
                Debug.Log("Nhân vật đã hết máu!");
                break; 
            }
        }
    }
}