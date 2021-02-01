﻿using System;
using System.Collections.Generic;

#nullable disable

namespace OvSuMusic.Models
{
    public class Perfil
    {
        public Perfil()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
