using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    Vector2 targetMouseDelta;
    [SerializeField]
    private GameObject Player;

    public float MouseX_sens = 1;
    public float MouseY_sens = 1;

    public float frequency = 1;
    public float amplitude = .001f;

    float RotX = 0;
    
    

    
    void Update()
    {
        RotX+=-targetMouseDelta.y*MouseY_sens;
        RotX = Mathf.Clamp(RotX,-90,90);
        targetMouseDelta = Mouse.current.delta.ReadValue()*Time.smoothDeltaTime;
        Player.transform.rotation *= Quaternion.Euler(0,targetMouseDelta.x*MouseX_sens,0);
        transform.localRotation = Quaternion.Euler(RotX,0,0);

        //print(RotX+" Clamped: "+Mathf.Clamp(RotX,-90,90));
        
        /*var WASDMove = transform.parent.GetComponent<WASDMove>();

        if(WASDMove.walking)
        {
            
            if(WASDMove.run)
            {
                transform.localPosition += new Vector3(0,Mathf.Sin(Time.time*frequency*(WASDMove.run_speed/3))*amplitude);
            }
            else{
                transform.localPosition += new Vector3(0,Mathf.Sin(Time.time*frequency*(WASDMove.speed/3))*amplitude);
            }
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.position,new Vector3(-0.009f,0.9f,0.312f),1);
        }*/
        
        

    }
}
