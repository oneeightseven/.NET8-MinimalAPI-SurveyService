using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testov.Models;

public class Question
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    
    public Survey? Survey { get; set; }
    
    public int? Surveyid { get; set; }
}
