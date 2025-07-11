using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interface;
using Application.ViewModels;

namespace Application.Services
{
    public class PrediccionMomentumService : IPredictores
    {
        public PrediccionResultado Calcular(EntradaDTO[] datos)
        {
            var ordenados = datos.ToList();

            int n = 5;
            List<string> resultados = new();

            for (int i = n; i < ordenados.Count; i++)
            {
                double vt = ordenados[i].Valor;
                double vtn = ordenados[i - n].Valor;

                if (vtn == 0)
                {
                    resultados.Add($"t={i}, Precio={vt}, ROC(5)= N/A (v[t-n] = 0)");
                    continue;
                }

                double roc = ((vt / vtn) - 1) * 100;
                resultados.Add($"t={i}, Precio={vt}, ROC(5)={roc:F2}%");
            }

            string tendencia;
            if (resultados.Count == 0)
            {
                tendencia = "Indefinida";
            }
            else
            {
                string lastLine = resultados.Last();
                double lastRoc = double.Parse(lastLine.Split("ROC(5)=")[1].Replace("%", ""));
                tendencia = lastRoc > 0 ? "Alcista" : "Bajista";
            }
;

            return new PrediccionResultado
            {
                Tipo = tendencia,
                Detalle = string.Join("<br>", resultados)
            };
        }
    }
}
