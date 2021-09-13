using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class move : MonoBehaviour
{

	float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
 
         if (Input.GetKey ("w")) {
             pos.z += speed * Time.deltaTime;
         }
         if (Input.GetKey ("s")) {
             pos.z -= speed * Time.deltaTime;
         }
         if (Input.GetKey ("d")) {
             pos.x += speed * Time.deltaTime;
         }
         if (Input.GetKey ("a")) {
             pos.x -= speed * Time.deltaTime;
         }
             
 
         transform.position = pos;

        if (SteamVR_Actions._default.Fly[SteamVR_Input_Sources.LeftHand].state)
            {
            Vector3 dir = SteamVR_Actions._default.Pose[SteamVR_Input_Sources.LeftHand].localRotation * Vector3.forward;
            transform.localPosition += dir * 0.1f;
            print(dir);
            }
    }

    private void OnCollisionEnter(Collision collision)
 {
      if ( collision.gameObject.tag == "Collectible" )
      {
           Destroy(collision.gameObject);
           Debug.Log("diamond");
      }


 }
}
