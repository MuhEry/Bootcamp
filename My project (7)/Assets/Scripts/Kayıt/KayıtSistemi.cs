using UnityEngine;

public class KayıtSistemi : MonoBehaviour
{
    public Transform karakterKonumu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.F6))
        {
            LoadGame();
        }
    }

    void SaveGame()
    {
        KayıtVerileri state = new KayıtVerileri
        {
            konumX = karakterKonumu.position.x,
            konumY = karakterKonumu.position.y,
            konumZ = karakterKonumu.position.z
        };

        string json = JsonUtility.ToJson(state);
        PlayerPrefs.SetString("Kayıt", json);
        PlayerPrefs.Save();

        Debug.Log("Konum kaydedildi!");
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("Kayıt"))
        {
            string json = PlayerPrefs.GetString("Kayıt");
            KayıtVerileri state = JsonUtility.FromJson<KayıtVerileri>(json);

            Vector3 konum = new Vector3(state.konumX, state.konumY, state.konumZ);
            karakterKonumu.position = konum;

            Debug.Log("Konum yüklendi!");
        }
        else
        {
            Debug.LogWarning("Kayıt bulunamadı!");
        }
    }
}
