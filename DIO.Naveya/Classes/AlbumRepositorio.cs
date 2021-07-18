using System.Collections.Generic;
using DIO.Naveya.Interfaces;

namespace DIO.Naveya.Classes
{
    public class AlbumRepositorio : IRepositorio<Album>
    {
        private List<Album> listaAlbum = new List<Album>();
        public void Atualiza(int id, Album objeto)
        {
            listaAlbum[id] = objeto;
        }
        public void Exclui(int id)
        {
            listaAlbum[id].Excluir();
        }
        public void Insere(Album objeto)
        {
            listaAlbum.Add(objeto);
        }
        public List<Album> Lista()
        {
            return listaAlbum;
        }
        public int ProximoId()
        {
            return listaAlbum.Count;
        }
        public Album RetornaPorId(int id)
        {
            return listaAlbum[id];
        }
    }
}