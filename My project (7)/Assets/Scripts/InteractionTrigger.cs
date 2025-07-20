using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InteractionTrigger : MonoBehaviour
{
    // === UI Ayarları ===
    [Header("UI Ayarları")]
    public TextMeshProUGUI interactionPromptText; // Etkileşim mesajı (F'ye bas gibi)
    public string promptMessage = "F'ye basarak etkileşime geç"; // Gösterilecek varsayılan mesaj

    public GameObject questImagePanel; // Görevle ilgili resmi/paneli içeren GameObject
    public string newQuestMessage; // Yeni görev alındığında gösterilecek mesaj (isteğe bağlı)

    // === Sahne ve Görev Ayarları ===
    [Header("Sahne ve Görev Ayarları")]
    public bool isSceneTransitionPoint = true; // Bu tetikleyici sahne geçişi yapıyor mu?
    public string targetSceneName; // Eğer sahne geçişi yapıyorsa, hedef sahnenin adı

    [Tooltip("Eğer görev ID'sine göre sahne yüklenecekse, burayı doldurun. " +
             "Boş bırakılırsa yukarıdaki 'Target Scene Name' kullanılır.")]
    public int questRelatedSceneID = -1; // -1 ise görev ID'sine bağlı değil

    // === Diğer Ayarlar ===
    public KeyCode interactionKey = KeyCode.F; // Etkileşim tuşu
    public string requiredPlayerTag = "Player"; // Oyuncu tag'i

    private bool playerIsInRange = false;

    // Singleton (Tekil Nesne) deseni için bir referans
    // QuestManager için de bunu kullanabiliriz
    // public static InteractionTrigger Instance { get; private set; } // Eğer bu bir Game Manager gibi merkezi bir şeyse

    void Awake()
    {
        // Örnek: Eğer bu bir Game Manager gibi tekil olacaksa
        // if (Instance != null && Instance != this)
        // {
        //     Destroy(gameObject);
        // }
        // else
        // {
        //     Instance = this;
        //     DontDestroyOnLoad(gameObject); // Eğer sahneler arası taşınacaksa
        // }
    }

    void Start()
    {
        // Başlangıçta tüm UI elemanlarını gizle
        if (interactionPromptText != null)
        {
            interactionPromptText.gameObject.SetActive(false);
        }
        if (questImagePanel != null)
        {
            questImagePanel.SetActive(false);
        }
    }

    void Update()
    {
        if (playerIsInRange && Input.GetKeyDown(interactionKey))
        {
            PerformInteraction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(requiredPlayerTag))
        {
            playerIsInRange = true;
            if (interactionPromptText != null)
            {
                interactionPromptText.text = promptMessage;
                interactionPromptText.gameObject.SetActive(true);
            }
            Debug.Log("Oyuncu etkileşim alanına girdi: " + gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(requiredPlayerTag))
        {
            playerIsInRange = false;
            // Oyuncu çıktığında UI elemanlarını gizle
            if (interactionPromptText != null)
            {
                interactionPromptText.gameObject.SetActive(false);
            }
            // NOT: questImagePanel'i ne zaman gizleyeceğinize karar verin.
            // Sadece etkileşim bittiğinde mi, yoksa sahne geçince mi?
            // Şimdilik burada gizlemiyoruz, çünkü bir kez gösterilip biten bir anlatım olabilir.
            // if (questImagePanel != null) { questImagePanel.SetActive(false); }
            Debug.Log("Oyuncu etkileşim alanından çıktı: " + gameObject.name);
        }
    }

    private void PerformInteraction()
    {
        Debug.Log("Etkileşim başlatıldı!");

        // 1. Görevle ilgili resim/panel göster (eğer varsa)
        if (questImagePanel != null)
        {
            questImagePanel.SetActive(true);
            // Burada ek mantık olabilir: resim animasyonu, ses vb.
            // Örneğin, bir süre sonra otomatik kapanmasını sağlayan bir Coroutine başlatabilirsiniz.
            // StartCoroutine(HideQuestImageAfterDelay(5f));
        }

        // 2. Yeni görev mesajı göster (eğer varsa)
        if (!string.IsNullOrEmpty(newQuestMessage))
        {
            // Bu mesajı da başka bir UI elemanında veya diyalog sisteminde gösterebilirsin
            Debug.Log("Yeni Görev Mesajı: " + newQuestMessage);
            // Örneğin: QuestManager.Instance.DisplayNewQuestNotification(newQuestMessage);
        }

        // 3. Sahne Geçişi (eğer belirlenmişse)
        if (isSceneTransitionPoint)
        {
            string finalSceneToLoad = "";

            // Eğer görev ID'si tanımlanmışsa, sahne adını QuestManager'dan al
            if (questRelatedSceneID != -1)
            {
                // BURADA ÖNEMLİ: QuestManager'dan sahne adını nasıl alacağın.
                // QuestManager'ı bir Singleton yapısı olarak düzenlemelisin.
                // Örneğin:
                // if (QuestManager.Instance != null) {
                //     finalSceneToLoad = QuestManager.Instance.GetSceneNameForQuest(questRelatedSceneID);
                // }
                // else {
                //     Debug.LogError("QuestManager sahneden bulunamadı!");
                // }

                // Şimdilik manuel atama veya QuestManager'dan alma mantığı buraya gelecek
                // Eğer QuestManager yoksa, yine de 'targetSceneName'i kullanabiliriz
                Debug.LogWarning("QuestManager entegrasyonu tamamlanmadı. 'targetSceneName' kullanılıyor.");
                finalSceneToLoad = targetSceneName; // Fallback
            }
            else // Görev ID'si tanımlı değilse, direkt targetSceneName kullan
            {
                finalSceneToLoad = targetSceneName;
            }

            if (!string.IsNullOrEmpty(finalSceneToLoad))
            {
                // UI'ı gizlemeden sahne geçişi yapma, aksi takdirde kullanıcı deneyimi kötüleşebilir.
                // Belki bir fade-out efekti ile birlikte gizlenmeli.
                if (interactionPromptText != null)
                {
                    interactionPromptText.gameObject.SetActive(false);
                }
                // Ayrıca questImagePanel de sahne geçişi öncesi kapatılmalı veya yeni sahneye aktarılmamalı.
                if (questImagePanel != null)
                {
                    questImagePanel.SetActive(false);
                }

                SceneManager.LoadScene(finalSceneToLoad);
                Debug.Log($"Sahne Yükleniyor: {finalSceneToLoad}");

                // Eğer sahne geçişinden sonra görevi tamamlamak istiyorsan:
                // if (QuestManager.Instance != null) {
                //     QuestManager.Instance.CompleteQuest("Mesaj Taşı"); // Örnek
                // }
            }
            else
            {
                Debug.LogWarning("Geçiş yapılacak sahne adı bulunamadı! Lütfen Inspector'dan veya QuestManager'dan atayın.");
            }
        }
        else
        {
            // Eğer sahne geçişi yoksa, sadece görevle ilgili paneli gösterip bir şeyler yapabilir.
            Debug.Log("Sadece etkileşim, sahne geçişi yok.");
            // Görev panelini gösterme ve gizleme mantığı burada daha netleşmeli.
            // Örneğin:
            // if (questImagePanel != null)
            // {
            //     StartCoroutine(HideQuestImageAfterDelay(5f));
            // }
        }
    }

    // Coroutine örneği: Bir UI panelini belirli bir süre sonra gizlemek için
    // System.Collections.IEnumerator kütüphanesini eklemeniz gerekir.
    // private System.Collections.IEnumerator HideQuestImageAfterDelay(float delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     if (questImagePanel != null)
    //     {
    //         questImagePanel.SetActive(false);
    //     }
    // }
}