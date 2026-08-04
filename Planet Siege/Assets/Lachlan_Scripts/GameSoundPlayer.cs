using UnityEngine;

public class GameSoundPlayer : MonoBehaviour
{
    public AudioSource meteorExplode;
    public AudioSource enemyShipExplode;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMeteorSound()
    {
        meteorExplode.Play();
    }

    public void PlayEnemyShipExplodeSound()
    {
        enemyShipExplode.Play();
    }
}
