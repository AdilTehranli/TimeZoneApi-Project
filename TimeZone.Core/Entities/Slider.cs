﻿using System.ComponentModel.DataAnnotations.Schema;
using TimeZone.Core.Entities.Commons;

namespace TimeZone.Core.Entities;

public class Slider:BaseEntity
{
    public string SliderImage { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
