import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlService } from '../url.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {
  urlService: UrlService;
  constructor(private httpClient: HttpClient, urlService: UrlService) {
    this.urlService = urlService
  }

  private genarateUrl(requestParamaters: RequestParameters): string {
    var url
    if (requestParamaters.fullEndPoint) {
      url = requestParamaters.fullEndPoint
    } else {
      var baseUrl = requestParamaters.differentBaseUrl ? `${requestParamaters.differentBaseUrl}` : `${this.urlService.baseUrl}`;
      var controller = requestParamaters.controller ? `/${requestParamaters.controller}` : "";
      var action = requestParamaters.action ? `/${requestParamaters.action}` : "";
      url = baseUrl + controller + action
    }
    return url;
  }

  get<T>(requestParamaters: Partial<RequestParameters>): Observable<T> {
    return this.httpClient.get<T>(this.genarateUrl(requestParamaters), { headers: requestParamaters.headers })
  }

  post<T>(requestParamaters: Partial<RequestParameters>, body: Partial<T>): Observable<T> {
    return this.httpClient.post<T>(this.genarateUrl(requestParamaters), body, { headers: requestParamaters.headers })
  }
  put<T>(requestParamaters: Partial<RequestParameters>, body: Partial<T>): Observable<T> {
    return this.httpClient.put<T>(this.genarateUrl(requestParamaters), body, { headers: requestParamaters.headers })
  }
  delete<T>(requestParamaters: Partial<RequestParameters>, id: string): Observable<T> {
    var url = `${this.genarateUrl(requestParamaters)}/${id}`
    return this.httpClient.delete<T>(url, { headers: requestParamaters.headers })
  }
}

export class RequestParameters {
  controller?: string
  action?: string
  differentBaseUrl?: string
  fullEndPoint?: string
  headers?: HttpHeaders
}
