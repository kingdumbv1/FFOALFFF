using UnityEngine;

public class SpeakerScript : MonoBehaviour
{
    Animator anim;
    [SerializeField] float timer;
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = Random.Range(5, 10);
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            anim.SetTrigger("Attack");
            timer = Random.Range(5, 10);
        }
    }
}
