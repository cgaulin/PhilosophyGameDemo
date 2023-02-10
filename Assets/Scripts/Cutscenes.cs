using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscenes : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject dialogueBoxOne;
    [SerializeField] GameObject backgroundBox;
    [SerializeField] GameObject fadeOut;
    [SerializeField] Animator anim;
    [SerializeField] Dialogue dialogue;
    [SerializeField] SpriteRenderer myDesk;
    [SerializeField] float speed;
    
    private bool stop = false;
    private bool stepOne = false;
    private bool trigger, triggerTwo = false;
    public bool completed = false;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Player>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stepOne)
        {
            if(!trigger)
            {
                player.transform.Translate(Vector2.left * speed * Time.deltaTime);
                anim.Play("Walk Left");
                if (player.transform.position.x <= -3.55f)
                {
                    trigger = true;                   
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            MovePlayer();
        }
    }

    private void FixedUpdate()
    {
        if(trigger && !triggerTwo)
        {
            player.transform.Translate(Vector2.down * speed * Time.deltaTime);
            anim.Play("Walk Down");
            if (player.transform.position.y <= -1.5f)
            {
                triggerTwo = true;
                player.transform.position = new Vector2(-3.55f, -1.5f);
                StartCoroutine(Sit());
            }
        }
        else
        {
            return;
        }
    }

    private void MovePlayer()
    {
        if (stop)
        {
            StopPlayerLeft();
        }
        else
        {
            MovePlayerLeft();
        }
        
        if (dialogue.finished)
        {
            stepOne = true;
        }
    }

    private void MovePlayerLeft()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.left;
        anim.Play("Walk Left");
    }

    private void StopPlayerLeft()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        anim.Play("Idle Left");
    }

    private IEnumerator Sit()
    {
        anim.Play("Idle Right");
        yield return new WaitForSeconds(1f);
        anim.Play("Idle Up");
        myDesk.sortingLayerName = "Background";
        player.transform.position = new Vector2(-2.55f, -1.5f);
        yield return new WaitForSeconds(3f);
        dialogueBoxOne.SetActive(true);
        backgroundBox.SetActive(true);
        StartCoroutine(Dream());
    }

    private IEnumerator Dream()
    {
        if (dialogue.alsoFinished)
        {
            fadeOut.SetActive(true);
        }
        yield return new WaitForSeconds(15f);
        completed = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "Trigger")
        {
            stop = true;
            dialogueBox.SetActive(true);
            backgroundBox.SetActive(true);
        }
    }
}
