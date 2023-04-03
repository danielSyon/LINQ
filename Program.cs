using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebaLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
           ControlEmpresasEmpleados prog=new ControlEmpresasEmpleados();

            Console.WriteLine("Introduce un id(1-2)");
            
            string entrada=Console.ReadLine();
            try {
                int entradaId= Convert.ToInt32(entrada);
                prog.getEmpleadosEmpresa(entradaId);
            }
            catch(Exception) {
                Console.WriteLine("No se ha podido introducir correctamente el dato");
            }
           
        }
    }

    class ControlEmpresasEmpleados
    {
        public ControlEmpresasEmpleados() { 
        listaEmpresas= new List<Empresa> ();
         listaEmpleados= new List<Empleado> ();

            listaEmpresas.Add(new Empresa { Id = 1, Nombre = "Syon" });

            listaEmpresas.Add(new Empresa { Id = 2, Nombre = "Panaderia Manolo" });

            listaEmpleados.Add(new Empleado { Cargo="Jefe",EmpresaId=1,Id=1,Nombre="Manolo",Salario=100000});

            listaEmpleados.Add(new Empleado { Cargo = "Empleado", EmpresaId = 1, Id = 2, Nombre = "Dani", Salario = 20000 });

            listaEmpleados.Add(new Empleado { Cargo = "Empleado", EmpresaId = 2, Id = 3, Nombre = "Pedro", Salario = 30000 });

            listaEmpleados.Add(new Empleado { Cargo = "Jefe", EmpresaId = 2, Id = 4, Nombre = "Luis", Salario = 900000 });



        }

        public void getJefe()
        {

            IEnumerable<Empleado> jefes = from empleado in listaEmpleados where empleado.Cargo == "Jefe" select empleado;

            foreach (Empleado empleado1 in jefes)
            {
                empleado1.getDatosEmpleado();
            }

        }

        public void getEmpleadosOrdenados()
        {
            IEnumerable<Empleado> empleados = from empleado in listaEmpleados orderby empleado.Nombre  select empleado;
            foreach (Empleado empleado1 in empleados)
            {
                empleado1.getDatosEmpleado();
            }

        }

        public void getEmpleadosEmpresa(int Id)
        {
            IEnumerable<Empleado> empleadosSyon = from empleado in listaEmpleados
                                              join empresa in listaEmpresas on empleado.EmpresaId equals empresa.Id
                                              where empresa.Id == Id
                                              select empleado;
            foreach (Empleado empleado1 in empleadosSyon)
            {
                empleado1.getDatosEmpleado();
            }

        }
        public List<Empresa> listaEmpresas;
        public List<Empleado> listaEmpleados;






    }

    class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public void getDatosEmpresa()
        {
            Console.WriteLine("Empresa {0} con Id {1}", Nombre, Id);
        }
    }

    class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public int EmpresaId { get; set; }


        public void getDatosEmpleado()
        {
            Console.WriteLine("Empleado {0} con Id {1} con  salario {2} y con cargo {3}" +
                " que pertenece a la empresa{4}", Nombre, Id,Salario,Cargo,EmpresaId);
        }
    }
}
