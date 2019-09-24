using System;
using practica01.Models;

namespace practica01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Probando el contexto de base de datos con MySQL");
            using (var db = new MysqlDbContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}
