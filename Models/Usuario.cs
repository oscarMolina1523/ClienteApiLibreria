﻿namespace ConsumirAPILibreria.Models
{
    public class Usuario : BaseEntity
    {
        public string NombreUsuario { get; set; }

        public string Contraseña { get; set; }

        public Guid IdEmpleado { get; set; }

        public Empleado empleado { get; set; }

        public Guid IdRol { get; set; }

        public Rol rol { get; set; }

        public bool Estado { get; set; }

        public string NameRol => rol.Descripcion;
    }
}
