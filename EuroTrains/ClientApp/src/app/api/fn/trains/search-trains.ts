/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { TrainsRm } from '../../models/trains-rm';

export interface SearchTrains$Params {
}

export function searchTrains(http: HttpClient, rootUrl: string, params?: SearchTrains$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<TrainsRm>>> {
  const rb = new RequestBuilder(rootUrl, searchTrains.PATH, 'get');
  if (params) {
  }

  return http.request(
    rb.build({ responseType: 'json', accept: 'text/json', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<Array<TrainsRm>>;
    })
  );
}

searchTrains.PATH = '/Trains';
