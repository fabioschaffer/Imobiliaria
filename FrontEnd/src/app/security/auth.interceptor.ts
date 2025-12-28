import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from './auth.service';
import { catchError, switchMap, throwError } from 'rxjs';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

    const authService = inject(AuthService);

    const token = authService.token;

    // 🔹 Adiciona token se existir
    const authRequest = token
        ? req.clone({
            setHeaders: { Authorization: `Bearer ${token}` }
        })
        : req;

    return next(authRequest).pipe(
        catchError((error: HttpErrorResponse) => {

            // 🔒 Se não for 401, apenas propaga
            if (error.status !== 401) {
                return throwError(() => error);
            }

            // 🔁 Evita loop infinito no refresh
            if (req.url.includes('/auth/refresh')) {
                authService.logout();
                return throwError(() => error);
            }

            // 🔄 Tenta renovar o token
            return authService.refreshToken().pipe(
                switchMap(response => {

                    const newToken = response.token;
                    authService.storeTokens(response);

                    const retryRequest = req.clone({
                        setHeaders: {
                            Authorization: `Bearer ${newToken}`
                        }
                    });

                    return next(retryRequest);
                }),
                catchError(err => {
                    // ❌ Refresh token expirou ou inválido
                    authService.logout();
                    return throwError(() => err);
                })
            );
        })
    );
};