using System;
using System.Data;
using WpfCRUDApp.Manager;

namespace WpfCRUDApp.Model.Book
{
    class BookRepository
    {
        public static void Save(string title, string author, string publisher, int price)
        {
            try
            {
                string query = "INSERT INTO book(title, author, publisher, price) VALUES ('" + title + "','" + author + "','" + publisher + "'," + price + ")";
                MySQLManager.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public static void Delete(int id)
        {
            try
            {
                string query = "DELETE FROM book WHERE id=" + id;
                MySQLManager.ExecuteQuery(query);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void Update(int id, string title, string author, string publisher, int price)
        {
            try
            {
                string query = "UPDATE book SET title='"+title+"', author='"
                    +author+"', publisher='"+publisher+"', price="
                    +price+" WHERE id=" + id;
                MySQLManager.ExecuteQuery(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet FindAll()
        {
            try
            {
                string query = "SELECT * FROM book";
                DataSet ds = MySQLManager.Select(query);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
