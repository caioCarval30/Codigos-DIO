using System;
using DIO.Naveya.Classes;

namespace DIO.Naveya.Classes
{
    public class Album : EntidadeBase
    {
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Artista {get; set;}
        private int Ano {get; set;}
        private Midia Midia {get; set;}
        private bool Excluido {get; set;}

        public Album (int id, Genero genero, string titulo, string artista, int ano, Midia midia)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Artista = artista;
            this.Ano = ano;
            this.Midia = midia;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Artista: " + this.Artista + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Tipo de mídia: " + this.Midia + Environment.NewLine;
            return retorno;
        }

        public string retornaArtista()
        {
            return this.Artista;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        internal int retornaId()
        {
            return this.Id;
        }

        internal string retornaExcluido()
        {
            if (this.Excluido == true)
            {
                return "*Excluído*";
            }
            else
            {
                return "Albúm disponível";
            }    
        }
        
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}