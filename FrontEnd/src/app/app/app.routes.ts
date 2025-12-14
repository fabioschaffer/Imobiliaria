import { Routes } from '@angular/router';
import { UnidadeFederacaoListagemComponent } from '../unidade-federacao/listagem/unidade-federacao-listagem.component';
import { UnidadeFederacaoCadastroComponent } from '../unidade-federacao/cadastro/unidade-federacao-cadastro.component';
import { ImovelCadastroComponent } from '../imovel/cadastro/imovel-cadastro.component';
import { ImovelListagemComponent } from '../imovel/listagem/imovel-listagem.component';

export const routes: Routes = [
    { path: 'unidadefederacaolistagem', component: UnidadeFederacaoListagemComponent },
    { path: 'unidadefederacaocadastro', component: UnidadeFederacaoCadastroComponent },
    { path: 'unidadefederacaocadastro', component: UnidadeFederacaoCadastroComponent },
    { path: 'imovel/cadastro', component: ImovelCadastroComponent },
    { path: 'imovel/listagem', component: ImovelListagemComponent },
];
