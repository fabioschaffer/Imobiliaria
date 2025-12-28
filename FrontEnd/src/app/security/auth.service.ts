import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private readonly API = environment.apiUrl + '/api/auth';

    constructor(private http: HttpClient) { }

    login(login: string, senha: string) {
        return this.http.post<any>(`${this.API}/login`, { Login: login, Password: senha })
            .pipe(
                tap(response => {
                    this.storeTokens(response);
                })
            );
    }

    refreshToken() {
        return this.http.post<any>(`${this.API}/refresh`, { RefreshToken: localStorage.getItem('refresh_token') }
        ).pipe(
            tap(response => {
                this.storeTokens(response);
            })
        );

    }

    storeTokens(response: any) {
        localStorage.setItem('access_token', response.token);
        localStorage.setItem('refresh_token', response.refreshToken);
    }


    logout() {
        localStorage.removeItem('access_token');
        localStorage.removeItem('refresh_token');
    }

    get token(): string | null {
        return localStorage.getItem('access_token');
    }

    isAuthenticated(): boolean {
        return !!this.token;
    }
}