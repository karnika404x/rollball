using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 0; 
    public TextMeshProUGUI countText;
    private float movementX;
    private float movementY;
    private int count;
    public GameObject winTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        winTextObject.SetActive(false);
        rb = GetComponent <Rigidbody>();
        count = 0;
        SetCountText();
    }
    private void FixedUpdate() 
   {
    
    Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
    rb.AddForce(movement * speed); 
   
   }

    void OnMove (InputValue movementValue)
   {
    Vector2 movementVector = movementValue.Get<Vector2>();
    movementX = movementVector.x; 
    movementY = movementVector.y; 
   
   }

    void OnTriggerEnter(Collider other) 
   {
        
        count= count+1;
        if (other.gameObject.CompareTag("PickUP")) 
       {
            SetCountText();
            other.gameObject.SetActive(false);
            
       }
       
   }
    void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count >= 12)
       {
           winTextObject.SetActive(true);
           Destroy(GameObject.FindGameObjectWithTag("Enemy"));
       }
   }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            {
                // Destroy the current object
                Destroy(gameObject); 
                // Update the winText to display "You Lose!"
                winTextObject.gameObject.SetActive(true);
                winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            }
    }
    
}
