using System.Collections.Generic;

namespace DIO.Projeto.Series.interfaces
{
  public interface iRepository<T>
  {
    List<T> List();
    T ReturnById(int id);
    void Insert(T entity);
    void Exclude(int id);
    void Update(int id, T entity);
    int NextId();
  }
}