using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip winnerSound, introSound, noSound, yesSound, darkSound, lightSound;
    static AudioSource audioSrc;

    void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        winnerSound = Resources.Load<AudioClip>("winner");
        introSound = Resources.Load<AudioClip>("intro");
        noSound = Resources.Load<AudioClip>("select_no");
        yesSound = Resources.Load<AudioClip>("select_yes");
        darkSound = Resources.Load<AudioClip>("dark_ding");
        lightSound = Resources.Load<AudioClip>("light_ding");
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "winner":
                audioSrc.PlayOneShot(winnerSound);
                break;
            case "intro":
                audioSrc.PlayOneShot(introSound);
                break;
            case "select_no":
                audioSrc.PlayOneShot(noSound);
                break;
            case "select_yes":
                audioSrc.PlayOneShot(yesSound);
                break;
            case "dark_ding":
                audioSrc.PlayOneShot(darkSound);
                break;
            case "light_ding":
                audioSrc.PlayOneShot(lightSound);
                break;
        }
    }
}
