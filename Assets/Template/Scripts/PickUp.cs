using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror{
    public class PickUp : NetworkBehaviour
    {
        new public Rigidbody rigidbody;

        public override void OnStartServer()
        {
            base.OnStartServer();

            // only simulate ball physics on server
            //rigidbody.simulated = true;
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        [ServerCallback]
        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log("Bang");
        }
    }
}

