import { Injectable } from '@angular/core';

import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor() {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let user = localStorage.getItem('name') == null ? request.body.name : localStorage.getItem('name');
    let pwd = localStorage.getItem('pwd') == null ? request.body.password : localStorage.getItem('pwd');
    request = request.clone({
      setHeaders: {
        Authorization: `{name: ${user}, password: ${pwd}}`
      }
    });
    return next.handle(request);
  }
}