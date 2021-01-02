using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    //cached component references
    AudioSource dropSound;
    [SerializeField] GameObject Teadrop;
    private Rigidbody2D drop;
    public float speed = 1f;
    public float time = 0;
    bool destroyed = false;
    // Start is called before the first frame update

    void Start()
    {
        dropSound = GetComponent<AudioSource>();
        InvokeRepeating("Instantiate", 1f, time);
        

    }
    public void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        time += Time.deltaTime; 
        if(destroyed == true)
        {
            speed += speed;
        }
       // speed += speed * Time.deltaTime;
        Debug.Log(speed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManagerScript.PlaySound();
        FindObjectOfType<GameStatus>().AddToScore();
        destroyed = true;
        Destroy(gameObject);
    }

    public void Instantiate()
    {
        float spawnPosition = Random.Range(-2.08f, 2.08f);
        Vector2 instantiatePosition = new Vector2(spawnPosition,4.7f);
        GameObject teaDropCreater = Instantiate(Teadrop, instantiatePosition, Quaternion.identity);
    }

}
