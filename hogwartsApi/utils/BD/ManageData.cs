using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hogwartsApi
{
    ///<summary>
    ///Clase para manipular la informacion de solicitudes
    ///</summary>
    public class ManageData
    {
        ///<summary>
        ///Ruta del archivo donde se almancenan los datos
        ///</summary>
        private static string path = @"document/BDTest.txt";
        public ManageData()
        {            
        }
        ///<summary>
        ///Listar las solicitudes
        ///</summary>
        ///<return>
        ///Devuelve los registros que se han registrado.
        ///</return>
        public static List<Student> ReadAll()
        {
            List<Student> result = new List<Student>();
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Student AuxStudent = new Student(s.Split(";"));
                    result.Add(AuxStudent);
                }
            }
            return result;
        }
        ///<summary>
        ///Registrar nuevas solicitudes
        ///</summary>
        ///<return>
        ///Devuelve el id del registro.
        ///</return>
        ///<param name="value">
        ///Informacion de la solicitud.
        ///</param>
        public static int Agregate(Student value)
        {
            List<Student> auxData = ReadAll();
            int id = 1;
            if (auxData.Count > 0)
            {
            id =
                (from data in ReadAll()
                 select data.Id).ToList().Max() + 1;           
            }
            using (StreamWriter outputFile = File.AppendText(path))
            {
                outputFile.WriteLine(
                   id + ";" +
                    value.Name + ";" +
                    value.LastName + ";" +
                    value.Age + ";" +
                    value.MagicHouse 
                    );
            }
            return id;
        }
        ///<summary>
        ///Modifica solicitudes
        ///</summary>
        ///<return>
        ///Devuelve el id del registro, en caso de error devuelve 0.
        ///</return>
        ///<param name="value">
        ///Informacion de la solicitud.
        ///</param>
        public static int Update(Student value)
        {
            List<Student> auxData = ReadAll();
            int index = auxData.FindIndex(e => e.Id == value.Id);
            if (index == -1)
            {
                return 0;
            }
            auxData[index] = value;
            File.WriteAllText(path, String.Empty);
            foreach (var item in auxData)
            {
                using (StreamWriter outputFile = File.AppendText(path))
                {
                    outputFile.WriteLine(
                        item.Id + ";" +
                        item.Name + ";" +
                        item.LastName + ";" +
                        item.Age + ";" +
                        item.MagicHouse 
                        );
                }
            }
            return value.Id;
        }
        ///<summary>
        ///Elimina solicitudes
        ///</summary>
        ///<return>
        ///Devuelve si elimino un registro
        ///</return>
        ///<param name="id">
        ///Id a eliminar.
        ///</param>
        public static bool Delete(int id)
        {
            List<Student> auxData = ReadAll();
            int index = auxData.FindIndex(e => e.Id == id);
            if (index == -1)
            {
                return false;
            }
            auxData = (from data in auxData
                       where
                       data.Id != id
                       select data).ToList();
            File.WriteAllText(path, String.Empty);
            foreach (var item in auxData)
            {
                using (StreamWriter outputFile = File.AppendText(path))
                {
                    outputFile.WriteLine(
                        item.Id + ";" +
                        item.Name + ";" +
                        item.LastName + ";" +
                        item.Age + ";" +
                        item.MagicHouse
                        );
                }
            }
            return true;
        }       
        
    }
}