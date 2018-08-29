using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public interface ISaver
    {
        void Save(object obj, string path);
    }
}
