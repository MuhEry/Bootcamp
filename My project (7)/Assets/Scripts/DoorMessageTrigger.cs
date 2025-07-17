using UnityEngine;
using TMPro; // TextMeshPro kullanmak i�in bu k�t�phaneyi ekleyin

public class DoorMessageTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI doorMessageText; // Inspector'dan ba�layaca��m�z UI metni
    [SerializeField] private string messageToShow = "E'ye basarak kap�y� kontrol et"; // G�sterilecek mesaj
    [SerializeField] private GameObject backgroundImageObject; // Arka plan resmini i�eren GameObject

    void Start()
    {
        // Oyun ba�lad���nda metni ve resmi gizle
        if (doorMessageText != null)
        {
            doorMessageText.gameObject.SetActive(false);
        }
        if (backgroundImageObject != null)
        {
            backgroundImageObject.SetActive(false);
        }
    }

    // Oyuncu tetikleyiciye girdi�inde �a�r�l�r
    private void OnTriggerEnter(Collider other)
    {
        // Oyuncu karakterinizin bir "Player" Tag'i oldu�undan emin olun
        if (other.CompareTag("Player"))
        {
            if (doorMessageText != null)
            {
                doorMessageText.text = messageToShow; // Mesaj� ayarla
                doorMessageText.gameObject.SetActive(true); // Metni g�r�n�r yap
            }
            if (backgroundImageObject != null)
            {
                backgroundImageObject.SetActive(true); // Arka plan resmini g�r�n�r yap
            }
        }
    }

    // Oyuncu tetikleyiciden ��kt���nda �a�r�l�r
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (doorMessageText != null)
            {
                doorMessageText.gameObject.SetActive(false); // Metni gizle
            }
            if (backgroundImageObject != null)
            {
                backgroundImageObject.SetActive(false); // Arka plan resmini gizle
            }
        }
    }
}