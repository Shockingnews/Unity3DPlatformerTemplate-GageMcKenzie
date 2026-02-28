using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   
    public GameObject player;
    public bool movingOn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.transform.position != gameObject.transform.position)
            {
                MovePlayer();
            }
            if (player.transform.position == gameObject.transform.position)
            {
                gameObject.SetActive(false);
            }
                
            return;
        }
        
            
        player = GameObject.FindWithTag("Player");
        if(player!= null)
        {
            gameObject.SetActive(false);
        }

        //gameObject.transform.position = player.transform.position;
    }

    public void MovePlayer()
    {

        
        

            player.transform.position = Vector3.MoveTowards(player.transform.position, gameObject.transform.position, 1f * Time.deltaTime);
        
            //if(player.transform.position == endZipLine.transform.position)
            //{
            //    movingOn = false;
            //}
        
    }

    public void ToggleActive()
    {
        
            gameObject.SetActive(true);
        
        
    }
}
