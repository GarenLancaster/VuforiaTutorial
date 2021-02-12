using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherControl : MonoBehaviour
{
    public AudioClip ClipSong;

    private float now;
    // Start is called before the first frame update
    void Start()
    {
        // Invoke("PlaySong",2.0f);
        now = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time-now>2)
            AudioSource.DestroyImmediate(ClipSong,true);
    }
    
    private void PlaySong()
    {
        AudioSource.PlayClipAtPoint(ClipSong,this.transform.position);
    }
}
