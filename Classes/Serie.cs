using System;

namespace DIO.Projeto.Series
{
  public class Serie : EntidadeBase
  {
    //   ATRIBUTES
    private Genre Genre { get; set; }
    private string Title { get; set; }
    private string Description { get; set; }
    private int Year { get; set; }
    private bool Excluded { get; set; }

    // Methods
    public Serie(int Id, Genre genre, string title, string description, int year)
    {
      this.Id = Id;
      this.Genre = genre;
      this.Title = title;
      this.Description = description;
      this.Year = year;
      this.Excluded = false;
    }

    public override string ToString()
    {
      string giveBack = "";
      giveBack += "Genre: " + this.Genre + Environment.NewLine;
      giveBack += "Title: " + this.Title + Environment.NewLine;
      giveBack += "Description: " + this.Description + Environment.NewLine;
      giveBack += "Year: " + this.Year + Environment.NewLine;
      giveBack += "Deleted: " + this.Excluded + Environment.NewLine;
      return giveBack;
    }

    public string returnTitle()
    {
      return this.Title;
    }

    public int returnId()
    {
      return this.Id;
    }

    public bool returnExcluded()
    {
      return this.Excluded;
    }

    public void Excludes()
    {
      this.Excluded = true;
    }



  }




}