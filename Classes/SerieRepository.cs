using System;
using System.Collections.Generic;
using DIO.Projeto.Series.interfaces;


namespace DIO.Projeto.Series
{
  public class SerieRepository : iRepository<Serie>
  {
    private List<Serie> listSerie = new List<Serie>();
    public void Exclude(int id)
    {
      listSerie[id].Excludes();
    }

    public void Insert(Serie entity)
    {
      listSerie.Add(entity);
    }

    public List<Serie> List()
    {
      return listSerie;
    }

    public int NextId()
    {
      return listSerie.Count;
    }

    public Serie ReturnById(int id)
    {
      return listSerie[id];
    }

    public void Update(int id, Serie entity)
    {
      listSerie[id] = entity;
    }
  }
}