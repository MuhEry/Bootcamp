using UnityEngine;
using TMPro; // TextMeshPro kullanmak için bu kütüphaneyi ekleyin

public class DoorMessageTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI doorMessageText; // Inspector'dan baðlayacaðýmýz UI metni
    [SerializeField] private string messageToShow = "E'ye basarak kapýyý kontrol et"; // Gösterilecek mesaj
    [SerializeField] private GameObject backgroundImageObject; // Arka plan resmini içeren GameObject

    void Start()
    {
        // Oyun baþladýðýnda metni ve resmi gizle
        if (doorMessageText != null)
        {
            doorMessageText.gameObject.SetActive(false);
        }
        if (backgroundImageObject != null)
        {
            backgroundImageObject.SetActive(false);
        }
    }

    // Oyuncu tetikleyiciye girdiðinde çaðrýlýr
    private void OnTriggerEnter(Collider other)
    {
        // Oyuncu karakterinizin bir "Player" Tag'i olduðundan emin olun
        if (other.CompareTag("Player"))
        {
            if (doorMessageText != null)
            {
                doorMessageText.text = messageToShow; // Mesajý ayarla
                doorMessageText.gameObject.SetActive(true); // Metni görünür yap
            }
            if (backgroundImageObject != null)
            {
                backgroundImageObject.SetActive(true); // Arka plan resmini görünür yap
            }
        }
    }

    // Oyuncu tetikleyiciden çýktýðýnda çaðrýlýr
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