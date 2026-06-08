using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }
   public void Setup()
   {


        soundManager.PlaySFX(soundManager.winSound);
    
        gameObject.SetActive(true);
   }

    public void Restart()
    {
        SceneManager.LoadScene("CharacterSelectScene");
    }


}
