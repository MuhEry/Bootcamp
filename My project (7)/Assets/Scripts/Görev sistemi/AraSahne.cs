using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AraSahne : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiMetin;    // Inspector’dan baðlayacaðýn TMP bileþeni
    [SerializeField] private TextMeshProUGUI uiSahneGecme;    // Inspector’dan baðlayacaðýn TMP bileþeni
    [SerializeField] private float delay = 0.05f;       // Harfler arasý gecikme
    [TextArea]
    [SerializeField] private string tamMetin;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Main");  // Oyun ana sahnesine geri dön
        }
    }

    void OnEnable()
    {
        StartCoroutine(ShowText());
    }

    public IEnumerator ShowText()
    {
        uiMetin.text = "";
        for (int i = 0; i < tamMetin.Length; i++)
        {
            uiMetin.text += tamMetin[i];
            yield return new WaitForSeconds(delay);
        }
        uiSahneGecme.text = "Geçmek için F";
    }
}