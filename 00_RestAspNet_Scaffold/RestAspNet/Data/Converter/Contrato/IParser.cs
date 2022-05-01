using System.Collections.Generic;

namespace RestAspNet.Data.Converter.Contrato
{
    public interface IParser<Origem, Destino>
    {
        Destino Parse(Origem origem);

        List<Destino> Parse(List<Origem> origem);
    }
}
