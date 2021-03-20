using UnityEngine;

public class Particles : MonoBehaviour
{
    public ParticleSystem effectsBlue;
    public ParticleSystem effectsRed;
    public void PlayEffectsBlue(Vector3 pos)
    {
        effectsBlue.transform.position = pos;
        effectsBlue.Play();
    }

    public void PlayEffectsRed(Vector3 pos)
    {
        effectsRed.transform.position = pos;
        effectsRed.Play();
    }
}
