using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CubeController: MonoBehaviour {

    // キューブのPrefab
    public GameObject cubePrefab;

    // 地面の位置
    private float groundLevel = -3.0f;

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    AudioSource audioSource;  

    public List<AudioClip> audioClip = new List<AudioClip>();  


    // Use this for initialization
    void Start () {

        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;

    }
	
	// Update is called once per frame
	void Update () {

        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "cubePrefab")
        {
            audioSource.PlayOneShot(audioClip[0]);
        }
        else if (coll.gameObject.tag == "ground")
        {
            audioSource.PlayOneShot(audioClip[0]);
        }

    }

   
}
