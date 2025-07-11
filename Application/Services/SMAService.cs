using Application.Interface;
using Application.ViewModels;

public class PrediccionSMAService : IPredictores
{
    public PrediccionResultado Calcular(EntradaDTO[] datos)
    {

        var ordenados = datos.OrderByDescending(d => d.Fecha).ToList();

        var smaCorta = ordenados.Take(5).Average(x => x.Valor);
        var smaLarga = ordenados.Take(20).Average(x => x.Valor);

        string tendencia = smaCorta > smaLarga ? "Alcista" : "Bajista";
        return new PrediccionResultado
        {
            Tipo = tendencia,
            Detalle = $"SMA Corta: {smaCorta:F2}, SMA Larga: {smaLarga:F2}"
        };
    }
}
