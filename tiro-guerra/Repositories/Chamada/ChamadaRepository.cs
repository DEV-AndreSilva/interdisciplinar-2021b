using System;
using System.Collections.Generic;
using TiroGuerra.Models;
using System.Data.SqlClient;
using System.Data;

namespace TiroGuerra.Repositories
{
    public class ChamadaRepository : BDContext, IChamadaRepository
    {
        public void Create(Chamada model)
        {
            try {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

               

                cmd.CommandText = "";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Instrucao", model.IdInstrucao);
                cmd.Parameters.AddWithValue("@Id_Atirador", model.IdAtirador);
                cmd.Parameters.AddWithValue("@Id_Responsavel", model.IdResponsavel);
                cmd.Parameters.AddWithValue("@Presenca", model.Presenca);


                cmd.ExecuteNonQuery();

            }catch(Exception ex) {
                // Armazenar a exceção em um log.
                Console.WriteLine(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        public List<Chamada> ReadAll()
        {
            try {
                List<Chamada> lista = new List<Chamada>();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "SELECT * FROM TB_Chamada";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()) 
                {
                    Chamada chamada = new Chamada();
                    chamada.IdInstrucao = reader.GetInt32(0);
                    chamada.IdAtirador = reader.GetInt32(1);
                    chamada.IdResponsavel = reader.GetInt32(2);
                    chamada.Presenca = reader.GetBoolean(3);


                    lista.Add(chamada);
                }

                return lista;
            }catch(Exception ex) {
                // Armazenar a exceção em um log.
                throw new Exception(ex.Message);
            }
            finally {
                Dispose();
            }
        }

        
    }
}