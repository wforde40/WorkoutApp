﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UiChallengeWorkoutApp.MobileAppService.Models
{
    public class Exercise
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


    }
}
