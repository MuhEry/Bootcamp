using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli
using TMPro; // TextMeshPro kullanýyorsak bu kütüphane gerekli

public class DoorInteraction : MonoBehaviour
{
    // Inspector'dan sürükleyip býrakacaðýmýz UI Text objesi
    // TextMeshPro kullandýðýmýz için TMPro.TextMeshProUGUI tipinde
    public TextMeshProUGUI doorPromptText;

    // Hangi göreve göre sahne yükleneceðini belirleyen basit bir deðiþken
    // Gerçek bir oyunda bu, GameManager gibi merkezi bir yerden gelmeli
    public int currentQuestID = 1; // Baþlangýçta 1. görevde olduðumuzu varsayalým

    // Görev ID'lerine göre yüklenecek sahne isimlerini tutan basit bir yapý
    // Daha karmaþýk görev sistemlerinde bu, ScriptableObject veya Dictionary olabilir
    [System.Serializable] // Bu sýnýfýn Inspector'da görünmesini saðlar
    public class QuestSceneMapping
    {
        public int questID;
        public string sceneName;
    }

    public QuestSceneMapping[] questSceneMappings; // Inspector'dan ayarlayacaðýz

    // Karakterin collider içinde olup olmadýðýný takip eden deðiþken
    private bool isPlayerInsideTrigger = false;

    void Start()
    {
        // Oyun baþladýðýnda UI yazýsýný gizle
        if (doorPromptText != null)
        {
            doorPromptText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Eðer oyuncu trigger'ýn içindeyse VE 'F' tuþuna basýldýysa
        if (isPlayerInsideTrigger && Input.GetKeyDown(KeyCode.F))
        {
            LoadQuestSpecificScene();
        }
    }

    // Karakter trigger'ýn içine girdiðinde çalýþýr
    private void OnTriggerEnter(Collider other)
    {
        // Giren objenin "Player" tag'ine sahip olup olmadýðýný kontrol et
        // Karakterinizin objesinde "Player" tag'i olduðundan emin olun!
        if (other.CompareTag("Player"))
        {
            isPlayerInsideTrigger = true;
            if (doorPromptText != null)
            {
                doorPromptText.gameObject.SetActive(true); // Yazýyý göster
            }
            Debug.Log("Oyuncu kapý trigger'ýna girdi!");
        }
    }

    // Karakter trigger'dan çýktýðýnda çalýþýr
    private void OnTriggerExit(Collider other)
    {
        // Çýkan objenin "Player" tag'ine sahip olup olmadýðýný kontrol et
        if (other.CompareTag("Player"))
        {
            isPlayerInsideTrigger = false;
            if (doorPromptText != null)
            {
                doorPromptText.gameObject.SetActive(false); // Yazýyý gizle
            }
            Debug.Log("Oyuncu kapý trigger'ýndan çýktý!");
        }
    }

    // Göreve özel sahneyi yükleyen metot
    private void LoadQuestSpecificScene()
    {
        string targetSceneName = "";

        // currentQuestID'ye göre doðru sahneyi bul
        foreach (var mapping in questSceneMappings)
        {
            if (mapping.questID == currentQuestID)
            {
                targetSceneName = mapping.sceneName;
                break; // Eþleþen sahne bulundu, döngüden çýk
            }
        }

        if (!string.IsNullOrEmpty(targetSceneName))
        {
            // Sahneyi yüklemeden önce UI yazýsýný gizle
            if (doorPromptText != null)
            {
                doorPromptText.gameObject.SetActive(false);
            }

            // Sahneyi yükle
            SceneManager.LoadScene(targetSceneName);
            Debug.Log($"Sahne yükleniyor: {targetSceneName} (Görev ID: {currentQuestID})");
        }
        else
        {
            Debug.LogError($"Hata: Görev ID {currentQuestID} için tanýmlanmýþ bir sahne bulunamadý!");
        }
    }
}
