import { Routes } from '@angular/router';
import { UnidadeFederacaoListagemComponent } from '../unidade-federacao/listagem/unidade-federacao-listagem.component';
import { UnidadeFederacaoCadastroComponent } from '../unidade-federacao/cadastro/unidade-federacao-cadastro.component';
import { ImovelCadastroComponent } from '../imovel/cadastro/imovel-cadastro.component';

export const routes: Routes = [
    { path: 'unidadefederacaolistagem', component: UnidadeFederacaoListagemComponent },
    { path: 'unidadefederacaocadastro', component: UnidadeFederacaoCadastroComponent },
    { path: 'unidadefederacaocadastro', component: UnidadeFederacaoCadastroComponent },
    { path: 'imovel/cadastro', component: ImovelCadastroComponent },
];
