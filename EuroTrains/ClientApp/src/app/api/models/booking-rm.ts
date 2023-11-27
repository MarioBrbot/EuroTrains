/* tslint:disable */
/* eslint-disable */
import { TimePlaceRm } from '../models/time-place-rm';
export interface BookingRm {
  arrival?: TimePlaceRm;
  company?: string | null;
  departure?: TimePlaceRm;
  numberOfBookedSeats?: number;
  passengerEmail?: string | null;
  price?: string | null;
  trainId?: string;
}
