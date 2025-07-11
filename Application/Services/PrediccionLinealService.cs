using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Application.ViewModels;

namespace Application.Services
{


    public class PrediccionLinealService : IPredictores
    {
        public PrediccionResultado Calcular(EntradaDTO[] datos)
        {
         

         
            var ordenados = datos.ToList();

            int n = ordenados.Count;
            double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"x: {i + 1}, y: {ordenados[i].Valor}");

                double x = i + 1; 
                double y = (double)ordenados[i].Valor;

                sumX += x;
                sumY += y;
                sumXY += x * y;
                sumX2 += x * x;
            }

            double m = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double b = (sumY - m * sumX) / n;

            double valorDia21 = m * (n + 1) + b;

            string tendencia = m > 0 ? "Alcista" : "Bajista";

            return new PrediccionResultado
            {
                Tipo = tendencia,
                Detalle = $"Valor estimado día 21: {valorDia21:F2}, pendiente: {m:F2}"
            };
        }
    }

}

