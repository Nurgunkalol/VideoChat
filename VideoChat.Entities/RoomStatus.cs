﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VideoChat.Entities
{
    public enum RoomStatus
    {
        [Description("В процессе")]
        Processing = 0,
        [Description("Окончен")]
        Completed = 1,
    }
}
