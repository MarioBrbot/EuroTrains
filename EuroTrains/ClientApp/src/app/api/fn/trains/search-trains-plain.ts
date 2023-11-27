/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { TrainsRm } from '../../models/trains-rm';

export interface SearchTrains$Plain$Params {
  fromDate?: string;
  toDate?: string;
  from?: string;
  destination?: string;
  numberOfPassengers?: number;
}

export function searchTrains$Plain(http: HttpClient, rootUrl: string, params?: SearchTrains$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<TrainsRm>>> {
  const rb = new RequestBuilder(rootUrl, searchTrains$Plain.PATH, 'get');
  if (params) {
    rb.query('fromDate', params.fromDate, {});
    rb.query('toDate', params.toDate, {});
    rb.query('from', params.from, {});
    rb.query('destination', params.destination, {});
    rb.query('numberOfPassengers', params.numberOfPassengers, {});
  }

  return http.request(
    rb.build({ responseType: 'text', accept: 'text/plain', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<Array<TrainsRm>>;
    })
  );
}

searchTrains$Plain.PATH = '/Trains';
