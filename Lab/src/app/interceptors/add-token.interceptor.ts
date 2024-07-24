import { HttpInterceptorFn } from '@angular/common/http';

export const addTokenInterceptor: HttpInterceptorFn = (req, next) => {
    let token = localStorage.getItem('token');
    if(token){
        req = req.clone({headers: req.headers.set('Authorization', `Bearer ${token}`)});
    }
    return next(req);
};
