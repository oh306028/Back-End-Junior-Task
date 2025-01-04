using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Participant    
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public DateTime WorkStart { get; set; }

    public DateTime WorkEnd { get; set; }
}



