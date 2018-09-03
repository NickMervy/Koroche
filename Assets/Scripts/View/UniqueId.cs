using UnityEngine;

namespace View
{
    public class UniqueId : MonoBehaviour
    {
        public int Id
        {
            get { return gameObject.GetInstanceID(); }
        }
    }
}