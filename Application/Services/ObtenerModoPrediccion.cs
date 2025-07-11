using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ENUM;
using Application.Interface;
using Application.ViewModels;

namespace Application.Services
{
    public sealed class ObtenerModoPrediccion
    {
   
        public static IPredictores obtenerModo()
        {
          switch(ModoPrediccionService.Instance.ModoActual)
            {
                case ModoPrediccionENUM.SMA:
                    return new PrediccionSMAService();
                case ModoPrediccionENUM.RegresionLineal:
                    return new PrediccionLinealService();
                case ModoPrediccionENUM.Momentum:
                    return new PrediccionMomentumService();
                default:
                    throw new NotImplementedException("El modo de predicción no está implementado.");
            }
        }
        
    }
}
