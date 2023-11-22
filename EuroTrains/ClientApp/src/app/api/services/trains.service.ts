/* tslint:disable */
/* eslint-disable */
import { HttpClient, HttpContext } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';

import { searchTrains } from '../fn/trains/search-trains';
import { SearchTrains$Params } from '../fn/trains/search-trains';
import { searchTrains$Plain } from '../fn/trains/search-trains-plain';
import { SearchTrains$Plain$Params } from '../fn/trains/search-trains-plain';
import { TrainsRm } from '../models/trains-rm';

@Injectable({ providedIn: 'root' })
export class TrainsService extends BaseService {
  constructor(config: ApiConfiguration, http: HttpClient) {
    super(config, http);
  }

  /** Path part for operation `searchTrains()` */
  static readonly SearchTrainsPath = '/Trains';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `searchTrains$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchTrains$Plain$Response(params?: SearchTrains$Plain$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<TrainsRm>>> {
    return searchTrains$Plain(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `searchTrains$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchTrains$Plain(params?: SearchTrains$Plain$Params, context?: HttpContext): Observable<Array<TrainsRm>> {
    return this.searchTrains$Plain$Response(params, context).pipe(
      map((r: StrictHttpResponse<Array<TrainsRm>>): Array<TrainsRm> => r.body)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `searchTrains()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchTrains$Response(params?: SearchTrains$Params, context?: HttpContext): Observable<StrictHttpResponse<Array<TrainsRm>>> {
    return searchTrains(this.http, this.rootUrl, params, context);
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `searchTrains$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  searchTrains(params?: SearchTrains$Params, context?: HttpContext): Observable<Array<TrainsRm>> {
    return this.searchTrains$Response(params, context).pipe(
      map((r: StrictHttpResponse<Array<TrainsRm>>): Array<TrainsRm> => r.body)
    );
  }

}
