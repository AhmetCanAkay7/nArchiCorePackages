using Core.Persistence.Repositories;

namespace Core.Persistence.Paging;
//Frontendçi için önemli kısım
public class Paginate<T> 
{
    public Paginate()
    {
        Items = Array.Empty<T>();
    }

    public int Size { get; set; }// Kaç tane veri var sayfamda
    public int Index  { get; set; }// Kaçıncı sayfadayım
    public int  Count { get; set; }// Toplam kayıt sayısı
    public int Pages { get; set; }// Toplam sayfa sayısı   
    public IList<T> Items { get; set; }
    public bool HasPrevious => Index > 1;
    public bool HasNext => Index+1 < Pages;
    
}