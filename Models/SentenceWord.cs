namespace Keepr.Models
{
  public class SentenceWord
  {
    public int Id { get; set; }
    public int WordId { get; set; }
    public int SentenceId { get; set; }
    public string UserId { get; set; }
  }
}