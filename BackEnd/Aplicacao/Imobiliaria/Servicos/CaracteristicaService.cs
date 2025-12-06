using Aplicacao.Imobiliaria.DTOs;
using Aplicacao.Imobiliaria.Interfaces;
using Dominio.Entidades.Imobiliaria;
using Repositorio.Interfaces;
using Repositorio.Interfaces.ImovelNS;

namespace Aplicacao.Imobiliaria.Servicos;
public class CaracteristicaService : ICaracteristicaService {

    private ICaracteristicaRepository CaracteristicaRepository ;

    public CaracteristicaService(ICaracteristicaRepository caracteristicaRepository)  {
        this.CaracteristicaRepository  = caracteristicaRepository;
    }

    public async Task<IEnumerable<CaracteristicaDTO>> ObterTodas()
    {
        var caracteristicas = await CaracteristicaRepository.ObterTodas();

        return caracteristicas.Select(c =>
            new CaracteristicaDTO(
                c.Id,
                c.Descricao
            )
        );
    }
}
