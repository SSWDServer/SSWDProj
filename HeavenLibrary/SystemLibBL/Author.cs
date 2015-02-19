using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLibDAL;
using SystemLibDTO;
using System.Data.SqlClient;

namespace SystemLibBL
{
    public class Author
    {
        private AuthorDTO authorDto;

        public Author()
        { 
            authorDto = new AuthorDTO();
        }

        public Author(AuthorDTO dto)
        {
            authorDto = dto;
        }

        public AuthorDTO dto
        {
            get { return authorDto; }
            set { authorDto = value; }
        }

        public int aid
        {
            get { return authorDto._aId; }
            set { authorDto._aId = value; }
        }

        public string FirstName
        {
            get { return authorDto._firstName; }
            set { authorDto._firstName = value; }
        }
        public string LastName
        {
            get { return authorDto._lastName; }
            set { authorDto._lastName = value; }
        }
        public int BirthYear
        {
            get { return authorDto._birthYear; }
            set { authorDto._birthYear = value; }
        }
        

        public static Author findAuthor(int aid)
        {
            Author newAuthor = new Author(dataAccess.getAuthor(aid));
            return newAuthor;
        }

        public static List<Author> getAllAuthors()
        { 
            List<AuthorDTO> authorDtoList = dataAccess.getAuthors();
            List<Author> authorList = new List<Author>();

            foreach (AuthorDTO ad in authorDtoList)
            {
                authorList.Add(new Author(ad));
            }
            return authorList;
        }
       
    }
}
