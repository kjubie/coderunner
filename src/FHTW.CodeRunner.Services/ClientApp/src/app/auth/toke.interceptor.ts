import { Injectable } from '@angular/core';
import { sha512 } from 'js-sha512';

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
    request = request.clone({
      setHeaders: {
        Authorization: `{name: ${request.body.name}, password: ${sha512(request.body.password)}}`
      }
    });
    return next.handle(request);
  }
}