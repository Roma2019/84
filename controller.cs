using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class controller : MonoBehaviour
{
    Transform tr;
    CharacterController contr;
    [SerializeField] TextMeshProUGUI text;
    public float speed = 8f;
    float horizontalSpeed = 2.0f;
    float gravityValue = -9.81f;
    bool isGrounded = false;
    float jumpHeight = 5f;
    float score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        tr= GetComponent<Transform>();
        contr = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X")*2;
        float vertical = Input.GetAxis("Vertical");
        tr.Rotate(0,h,0);
        contr.Move(tr.forward * vertical * speed * Time.deltaTime);
        contr.Move(tr.up * gravityValue * Time.deltaTime);
        if(Input.GetKeyDown("space")&& isGrounded == true){
            contr.Move(tr.up * jumpHeight);
        }
        isGrounded = false;
    }
    
    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag == "ground"){
            isGrounded = true;
        }
        if(col.gameObject.tag == "score"){
            score = score + 0.5;
            text.text = score + "";
            Destroy(col.gameObject);
        }
    }
}
