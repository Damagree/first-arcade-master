using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechnomediaLabs;

namespace Zetcil
{

    public class RandomController : MonoBehaviour
    {
        public bool isEnabled;
        [ReadOnly] public bool Validation;

        [Header("Card Settings")]
        public List<GameObject> Card;

        [Header("Container Settings")]
        public List<GameObject> Container;

        // Start is called before the first frame update
        void Start()
        {
            if (Card.Count == Container.Count)
            {
                Validation = true;
            } else
            {
                Validation = false;
            }
            Shuffle(Card);
            Replacement();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void Replacement()
        {
            for (int i = 0; i < Container.Count; i++)
            {
                Container[i].GetComponent<MeshRenderer>().enabled = false;
            }
            for (int i = 0; i < Card.Count; i++)
            {
                Card[i].transform.localScale = Container[i].transform.localScale;
                Card[i].transform.position = Container[i].transform.position;
            }
        }

        void Shuffle(List<GameObject> a)
        {
            // Loop array
            for (int i = a.Count - 1; i > 0; i--)
            {
                // Randomize a number between 0 and i (so that the range decreases each time)
                int rnd = UnityEngine.Random.Range(0, i);

                // Save the value of the current i, otherwise it'll overwrite when we swap the values
                GameObject temp = a[i];

                // Swap the new and old values
                a[i] = a[rnd];
                a[rnd] = temp;
            }
        }
    }
}
