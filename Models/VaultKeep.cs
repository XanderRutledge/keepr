using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{

  //data transfer object
  public class VaultKeep
  {
    public int Id { get; set; }
    [Required]
    public int KeepId { get; set; }
    [Required]
    public int VaultId { get; set; }
    public string UserId { get; set; }
    
  }

}