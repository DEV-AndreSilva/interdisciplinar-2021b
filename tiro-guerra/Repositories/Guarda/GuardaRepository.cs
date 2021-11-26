using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class GuardaRepository: BDContext, IGuardaRepository
    {
        public void Create(List<Guarda> Guardas, List<Guarnicao> Guarnicoes)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;


                // 0 7 14 21 28 35 42 49
                // 1 8 15 22 29 36 43 50
                // 2 9 16 23 30 37 44 51
                // 3 10 17 24 31 38 45 52
                // 4 11 18 25 32 39 46 53
                // 5 12 19 26 33 40 47 54
                // 6 13 20 27 34 41 48 55


                for(int i = 0; i<=6; i++)
                {
                     Console.WriteLine("Indice i "+i);
                    for(int v = i; v<56; v = v +7)
                    {
                        Console.WriteLine("Indice v "+v);
                        cmd.Parameters.Clear();
                        cmd.CommandText = "CREATE_GUARDA";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id_Atirador", Guardas[v].IdAtirador);
                        cmd.Parameters.AddWithValue("@Id_Guarnicao", Guarnicoes[i].Id);
                        cmd.Parameters.AddWithValue("@Presenca", true);
                        cmd.Parameters.AddWithValue("@Funcao",Guardas[v].Funcao);

                        cmd.ExecuteNonQuery();
                        
                    }
                    Console.WriteLine("-----------------");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public Guarda Read(int id)
        {

            return null;
        }
        public void Update(int id, Guarda model)
        {
            

        }

        public void Delete(int id)
        {

        }
    }
}