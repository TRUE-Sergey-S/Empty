using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmptyTemplateWebApiJwtAuthPsql.Models;

public class TestData
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { init; get; }

    [Required] 
    public string TestString { get; set; }  = "";
    
    [Required] 
    public DateTime GetDateTime { get; set; }
}