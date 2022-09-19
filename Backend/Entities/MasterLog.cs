using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class MasterLog
{
    public int Id { get; set; }
    public string? Message { get; set; }
    public string? MessageTemplate { get; set; }
    public string? Level { get; set; }
    public byte[] TimeStamp { get; set; }
    public string? Exception { get; set; }
    public string? LogEvent { get; set; }
    public string? UserName { get; set; }
    public string? IP { get; set; }

    public MasterLog() {

    }

}