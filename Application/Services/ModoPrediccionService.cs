using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ENUM;

namespace Application.Services
{
    public sealed class ModoPrediccionService
    {
        private ModoPrediccionService()
        {

        }
        public static ModoPrediccionService Instance { get; } = new();
        public ModoPrediccionENUM ModoActual { get; private set; } = ModoPrediccionENUM.SMA;
        public void EstablecerModo(ModoPrediccionENUM modo)
        {
            ModoActual = modo;
        }

    }
}
