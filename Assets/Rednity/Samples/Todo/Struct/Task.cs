﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Rednity.TodoSample
{
    public class Task  {

        private string _label;
        private Guid _id;

        public string Label { get { return _label; } }
        public Guid Id { get { return _id; } }
        public bool done;

        public Task(string label)
        {
            _id = Guid.NewGuid();
            _label = label;
        }
    }
}
