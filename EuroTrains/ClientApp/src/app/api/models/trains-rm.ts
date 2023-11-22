/* tslint:disable */
/* eslint-disable */
import { TimePlaceRm } from '../models/time-place-rm';
export interface TrainsRm {
  arrival?: TimePlaceRm;
  company?: string | null;
  departure?: TimePlaceRm;
  id?: string;
  price?: string | null;
  remainingNumberOfSeats?: number;
}
