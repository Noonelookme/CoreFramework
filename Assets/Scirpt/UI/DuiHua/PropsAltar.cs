using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        
        public List<SpriteRenderer> runes;
        public float lerpSpeed;
        public GameObject text;
        private Color curColor;
        private Color targetColor;
        public bool open;
        void Start()
        {
            text.SetActive(false);
            open = false;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 1);
            open = true;
           
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 0);
            open = false;
        }

        public void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);
         

            foreach (var r in runes)
            {
                r.color = curColor;
            }
            if (Input.GetKeyDown(KeyCode.E) && open == true )
            {
                text.SetActive(true);
                GameObject.Find("Player").GetComponent<PlayerInput>().enabled = false;
            }

        }
        
    }
}
