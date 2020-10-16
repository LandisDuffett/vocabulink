namespace Keepr.Models
{
  public class Sentence
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Text { get; set; }

  }

  public class SentenceWordSentenceViewModel : Sentence
  {
    public int SentenceWordId { get; set; }
  }
}