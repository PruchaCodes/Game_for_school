using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
   public void Setup()
   {
      gameObject.SetActive(true);
   }

    public void Restart()
    {
        SceneManager.LoadScene("CharacterSelectScene");
    }


}
