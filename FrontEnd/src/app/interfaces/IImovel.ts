import { IImovelCaracteristica } from "./IImovelCaracteristica";

export interface IImovel {
    id: number;
    tipoImovel: number;
    area: number;
    quartos: number;
    vagasGaragem: number;
    valor: number;
    caracteristicas: IImovelCaracteristica[]
}

export interface IImovelPaginacao {
    id: number;
    tipoImovel: number;
    area: number;
    quartos: number;
    vagasGaragem: number;
    valor: number;
    caracteristicas: IImovelCaracteristica[],
    totalLinhas: number;
}
