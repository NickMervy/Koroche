using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Services
{
    public class RandomService
    {
        public float RandomRange(float a, float b)
        {
            return Random.Range(a, b);
        }

        public int RandomRange(int a, int b)
        {
            return Random.Range(a, b);
        }

        public T FromCollection<T>(IEnumerable<T> collection)
        {
            var randomIndex = UnityEngine.Random.Range(0, collection.Count());
            return collection.ElementAt(randomIndex);
        }

        public IEnumerable<T> FromCollectionAmount<T>(IEnumerable<T> collection, int amount)
        {
            var result = new T[amount];
            var numToChoose = amount;

            for (var numLeft = collection.Count(); numLeft > 0; numLeft--)
            {
                var prob = (float)numToChoose / (float)numLeft;

                if (UnityEngine.Random.value <= prob)
                {
                    numToChoose--;
                    result[numToChoose] = collection.ElementAt(numLeft - 1);

                    if (numToChoose == 0)
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}