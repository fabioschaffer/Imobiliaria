namespace Util.Validacoes;

public class ValidacaoHelper {

    public static void Validar(bool condicao, string mensagem) {
        if (condicao)
            throw new Exception(mensagem);
    }

}
