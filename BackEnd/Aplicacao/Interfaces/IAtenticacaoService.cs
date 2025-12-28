using Aplicacao.DTOs;

namespace Aplicacao.Interfaces;
public interface IAtenticacaoService {
    Task<LoginResponseDTO> Autenticar(LoginRequestDTO dto);
}