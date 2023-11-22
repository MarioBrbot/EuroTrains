/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';
import { StrictHttpResponse } from '../../strict-http-response';
import { RequestBuilder } from '../../request-builder';

import { TrainsRm } from '../../models/trains-rm';

export interface FindTrains$Params {
  id: string;
}

export function findTrains(http: HttpClient, rootUrl: string, params: FindTrains$Params, context?: HttpContext): Observable<StrictHttpResponse<TrainsRm>> {
  const rb = new RequestBuilder(rootUrl, findTrains.PATH, 'get');
  if (params) {
    rb.path('id', params.id, {});
  }

  return http.request(
    rb.build({ responseType: 'json', accept: 'text/json', context })
  ).pipe(
    filter((r: any): r is HttpResponse<any> => r instanceof HttpResponse),
    map((r: HttpResponse<any>) => {
      return r as StrictHttpResponse<TrainsRm>;
    })
  );
}

findTrains.PATH = '/Trains/{id}';
