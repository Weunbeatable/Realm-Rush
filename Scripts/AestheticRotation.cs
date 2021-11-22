using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AestheticRotation : MonoBehaviour
{
    // This script creates two different cubes: one red which is rotated using Space.Self; one green which is rotated using Space.World.
    // Add it onto any GameObject in a scene and hit play to see it run. The rotation is controlled using xAngle, yAngle and zAngle, modifiable on the inspector.

    
        public float xAngle, yAngle, zAngle;
        [SerializeField] float roatateFactor = 15f;

       

        void Awake()
        {
           

           
          
           transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
        
           
        }

        void Update()
        {
          
            transform.Rotate(xAngle * Time.deltaTime * roatateFactor, yAngle * Time.deltaTime * roatateFactor, zAngle  * Time.deltaTime * roatateFactor, Space.Self) ;
        }
    }

