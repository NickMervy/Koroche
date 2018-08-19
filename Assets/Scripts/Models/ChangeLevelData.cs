﻿using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Models
{
    public class ChangeLevelData
    {
        public string CallerScene;
        public string TargetScene;
        public AsyncOperation Operation;
        public int ParallelProcesses;
    }
}