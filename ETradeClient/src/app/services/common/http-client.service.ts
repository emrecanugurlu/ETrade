import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlService } from '../url.service';
import {generate, Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {
  urlService: UrlService;
  constructor(private httpClient: HttpClient, urlService: UrlService) {
    this.urlService = urlService
  }

  private generateUrl(requestParamaters: RequestParameters): string {
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

  get<T>(requestParamaters: Partial<RequestParameters>,id?:string): Observable<T> {
    var url : string;
    if (id){
      url = requestParamaters.queryString ?`${this.generateUrl(requestParamaters)}` + "/" + `${id}`+ "?" + requestParamaters.queryString : `${this.generateUrl(requestParamaters)}` + "/" + `${id}`
    }else {
      url = requestParamaters.queryString ?`${this.generateUrl(requestParamaters)}` + "?" + requestParamaters.queryString : this.generateUrl(requestParamaters)
    }

    return this.httpClient.get<T>(url, { headers: requestParamaters.headers })
  }

  post<T>(requestParamaters: Partial<RequestParameters>, body: Partial<T>): Observable<T> {
    return this.httpClient.post<T>(this.generateUrl(requestParamaters), body, { headers: requestParamaters.headers })
  }
  put<T>(requestParamaters: Partial<RequestParameters>, body: Partial<T>): Observable<T> {
    return this.httpClient.put<T>(this.generateUrl(requestParamaters), body, { headers: requestParamaters.headers })
  }
  delete<T>(requestParamaters: Partial<RequestParameters>, id: string): Observable<T> {
    var url = `${this.generateUrl(requestParamaters)}/${id}`
    return this.httpClient.delete<T>(url, { headers: requestParamaters.headers })
  }
}

export class RequestParameters {
  controller?: string
  action?: string
  queryString? : string
  differentBaseUrl?: string
  fullEndPoint?: string
  headers?: HttpHeaders
}
