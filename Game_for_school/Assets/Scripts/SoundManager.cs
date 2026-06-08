using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [Header("------- Audio Sources -------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------- Audio Clips -------")]
    public AudioClip backgroundMusic;
    public AudioClip dmgTaken;
    public AudioClip StaminaRegen;
    public AudioClip AttackSound;
    public AudioClip ClickSound;
    public AudioClip LvlUpSound;
    public AudioClip CoinSound;
    public AudioClip FireballSound;
    public AudioClip RageSound;
    public AudioClip SneakAttackSound;
    public AudioClip EnemyAttackSound;
    public AudioClip HealSound;
    public AudioClip CritSound;
    public AudioClip winSound;
    public AudioClip loseSound;


    private void Start()
    {
        musicSource.volume = 10f;
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }




}
