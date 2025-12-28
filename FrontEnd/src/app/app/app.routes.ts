import { Routes } from '@angular/router';
import { UnidadeFederacaoListagemComponent } from '../unidade-federacao/listagem/unidade-federacao-listagem.component';
import { ImovelCadastroComponent } from '../imovel/cadastro/imovel-cadastro.component';
import { ImovelListagemComponent } from '../imovel/listagem/imovel-listagem.component';
import { PesquisaImovelComponent } from '../pesquisa-imovel/pesquisa-imovel.component';
import { InicialComponent } from './interno/inicial/inicial.component';
import { HomeComponent } from '../interno/home/home.component';
import { UnidadeFederacaoCadastroComponent } from '../unidade-federacao/cadastro/unidade-federacao-cadastro.component';
import { InicialExternoComponent } from '../externo/inicial/inicial.externo.component';
import { LoginComponent } from '../login/login.component';
import { SobreComponent } from '../externo/sobre/sobre.component';
import { authGuard } from '../security/auth.guard';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'externo/pesquisa-imovel',
        pathMatch: 'full'
    },
    {
        path: 'externo',
        component: InicialExternoComponent,
        children: [
            {
                path: 'pesquisa-imovel',
                component: PesquisaImovelComponent
            },
            {
                path: 'login',
                component: LoginComponent
            },
            {
                path: 'sobre',
                component: SobreComponent
            }
        ]
    },
    {
        path: 'interno',
        canActivate: [authGuard],
        component: InicialComponent,
        children: [
            {
                path: 'inicial',
                component: HomeComponent
            },
            {
                path: 'uf',
                children: [
                    {
                        path: 'listagem',
                        component: UnidadeFederacaoListagemComponent
                    },
                    {
                        path: 'cadastro',
                        component: UnidadeFederacaoCadastroComponent
                    },
                    {
                        path: '',
                        redirectTo: 'listagem',
                        pathMatch: 'full'
                    }
                ]
            },
            {
                path: 'imovel',
                children: [
                    {
                        path: 'listagem',
                        component: ImovelListagemComponent
                    },
                    {
                        path: 'cadastro',
                        component: ImovelCadastroComponent
                    },
                    {
                        path: '',
                        redirectTo: 'listagem',
                        pathMatch: 'full'
                    }
                ]
            }
        ]
    }
];
