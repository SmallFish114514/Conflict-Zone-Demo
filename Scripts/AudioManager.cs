using UnityEngine;
public class AudioManager : MonoBehaviour
{    
    private AudioSource audioSource;
    private void Awake()
    {        
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource.Play();
        audioSource.loop = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
