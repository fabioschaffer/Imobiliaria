import { Routes } from '@angular/router';
import { UnidadeFederacaoListagemComponent } from '../unidade-federacao/listagem/unidade-federacao-listagem.component';
import { UnidadeFederacaoComponent } from '../unidade-federacao/cadastro/unidade-federacao-cadastro.component';

export const routes: Routes = [
    { path: 'unidadefederacaolistagem', component: UnidadeFederacaoListagemComponent },
    { path: 'unidadefederacaocadastro', component: UnidadeFederacaoComponent },
];
